using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using LoginetWebApp.Abstract;
using LoginetWebApp.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LoginetWebApp.Impl
{
    /// <summary>
    /// Простая реализация источника данных. Не предусматирвает кэширования данных с предыдущих запросов.
    /// </summary>
    public class DataSource
        : IDataSource
    {
        private readonly string _dataSourceUri;
        private readonly WebClient _webClient;

        public DataSource(string dataSourceUri)
        {
            if (dataSourceUri == null) throw new ArgumentNullException("dataSourceUri");

            _dataSourceUri = dataSourceUri;
            _webClient = new WebClient();
        }

        /// <summary>
        /// Возвращает список пользователей
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetUsers()
        {
            var uri = new Uri(string.Format("{0}/{1}/", _dataSourceUri, "users"));

            return ReadEnumerable<User>(uri);
        }

        /// <summary>
        /// Возвращает пользователя по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id)
        {
            var uri = new Uri(string.Format("{0}/{1}/{2}", _dataSourceUri, "users", id));

            return ReadObject<User>(uri);
        }

        /// <summary>
        /// Возвращает список альбомов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Album> GetAlbums()
        {
            var uri = new Uri(string.Format("{0}/{1}/", _dataSourceUri, "albums"));

            return ReadEnumerable<Album>(uri);
        }

        /// <summary>
        /// Возвращает альбом по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Album GetAlbum(int id)
        {
            var uri = new Uri(string.Format("{0}/{1}/{2}", _dataSourceUri, "albums", id));

            return ReadObject<Album>(uri);
        }

        private T ReadObject<T>(Uri uri) where T : class
        {
            try
            {
                using (var stream = _webClient.OpenRead(uri))
                {
                    if (stream == null)
                        throw new InvalidOperationException(string.Format("Can't open uri '{0}'.", uri.AbsolutePath));

                    using (var streamReader = new StreamReader(stream, Encoding.UTF8)) // Исходим из того, что API выдаёт UTF-8 строки
                    {
                        var data = streamReader.ReadToEnd();

                        return JsonConvert.DeserializeObject<T>(data);
                    }
                }
            }
            catch (WebException exception)
            {
                var httpWebResponse = exception.Response as HttpWebResponse;

                if (httpWebResponse != null && httpWebResponse.StatusCode == HttpStatusCode.NotFound)
                    return null;

                throw;
            }
        }

        private IEnumerable<T> ReadEnumerable<T>(Uri uri) where T : class
        {
            using (var stream = _webClient.OpenRead(uri))
            {
                if (stream == null)
                    throw new InvalidOperationException(string.Format("Can't open uri '{0}'.", uri.AbsolutePath));

                using (var streamReader = new StreamReader(stream, Encoding.UTF8)) // Исходим из того, что API выдаёт UTF-8 строки
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    while (jsonTextReader.Read())
                    {
                        if (jsonTextReader.TokenType == JsonToken.StartObject)
                        {
                            var obj = JObject.Load(jsonTextReader);
                            yield return obj.ToObject<T>();
                        }
                    }
                }
            }
        }
    }
}