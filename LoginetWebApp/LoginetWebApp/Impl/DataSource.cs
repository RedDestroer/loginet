using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using LoginetWebApp.Abstract;
using LoginetWebApp.Domain;
using Newtonsoft.Json;

namespace LoginetWebApp.Impl
{
    /// <summary>
    /// Простая реализация источника данных. Не предусматирвает кэширования данных с предыдущих запросов.
    /// </summary>
    public class DataSource
        : IDataSource
    {
        private readonly string _dataSourceUri;
        //private readonly WebClient _webClient;

        public DataSource(string dataSourceUri)
        {
            if (dataSourceUri == null) throw new ArgumentNullException("dataSourceUri");

            _dataSourceUri = dataSourceUri;
            //_webClient = new WebClient();
        }

        /// <summary>
        /// Возвращает список пользователей
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetUsers()
        {
            //var uri = new Uri(string.Format("{0}/{1}", _dataSourceUri, "users/"));

            //using (var stream = _webClient.OpenRead(uri))
            //{
            //    if (stream == null)
            //        throw new InvalidOperationException(string.Format("Can't open uri '{0}'.", uri.AbsolutePath));

            //    using (var streamReader = new StreamReader(stream, Encoding.UTF8))
            //    {
            //        return JsonConvert.DeserializeObject<IEnumerable<User>>(streamReader.ReadToEnd());
            //    }
            //}

            return new List<User>();
        }

        /// <summary>
        /// Возвращает список альбомов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Album> GetAlbums()
        {
            return new Album[]
                {
                    new Album
                        {
                            Id = 1,
                            UserId = 1,
                            Name = "a1"
                        },
                    new Album
                        {
                            Id = 2,
                            UserId = 1,
                            Name = "a2"
                        }
                };
        }
    }
}