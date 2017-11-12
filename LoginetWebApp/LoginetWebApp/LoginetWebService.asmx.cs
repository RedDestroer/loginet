using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Services;
using System.Xml.Serialization;
using LoginetWebApp.Abstract;
using LoginetWebApp.Impl;
using LoginetWebApp.LoginetWebServiceTypes;
using Newtonsoft.Json;

namespace LoginetWebApp
{
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [WebService(Description = "Тестовый сервис", Namespace = XmlNs)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LoginetWebService 
        : WebService
    {
        public const string XmlNs = "http://tempuri.org/";
        private readonly IDataSource _dataSource;

        public LoginetWebService()
        {
            _dataSource = Config.Container.ResolveDataSource();
        }

        [WebMethod(Description = "Получение списка всех пользователей")]
        public string GetUsers(GetUsersRequest request)
        {
            return GetResponse(
                request,
                () => new GetUsersResponse
                    {
                        User = _dataSource.GetUsers()
                            .ToArray()
                    });
        }

        [WebMethod(Description = "Получение пользователя по ID")]
        public string GetUser(GetUserRequest request)
        {
            var user = _dataSource.GetUsers()
                .FirstOrDefault(o => o.Id == request.UserId);

            // В т.з. не указано как следует организовать обработку ошибок, по-этому тут в случае если пользователь не найден поднимаю исключение
            if (user == null)
                throw new WebException(string.Format("User with ID='{0} not found.'", request.UserId), WebExceptionStatus.UnknownError);

            return GetResponse(
                request,
                () => new GetUserResponse
                    {
                        User = user
                    });
        }

        [WebMethod(Description = "Получение списка всех альбомов")]
        public string GetAlbums(GetAlbumsRequest request)
        {
            return GetResponse(
                request,
                () => new GetAlbumsResponse
                    {
                        Albums = _dataSource.GetAlbums()
                            .ToArray()
                    });
        }

        [WebMethod(Description = "Получение альбома по ID")]
        public string GetAlbum(GetAlbumRequest request)
        {
            var album = _dataSource.GetAlbums()
                .FirstOrDefault(o => o.Id == request.AlbumId);

            // В т.з. не указано как следует организовать обработку ошибок, по-этому тут в случае если альбом не найден поднимаю исключение
            if (album == null)
                throw new WebException(string.Format("Album with ID='{0} not found.'", request.AlbumId), WebExceptionStatus.UnknownError);

            return GetResponse(
                request,
                () => new GetAlbumResponse
                    {
                        Album = album
                    });
        }

        [WebMethod(Description = "Получение всех альбомов пользователя по его ID")]
        public string GetUserAlbums(GetUserAlbumsRequest request)
        {
            return GetResponse(
                request,
                () => new GetUserAlbumsResponse
                    {
                        Albums = _dataSource.GetAlbums()
                            .Where(o => o.UserId == request.UserId)
                            .ToArray()
                    });
        }

        private static string GetResponse<T>(RequestBase request, Func<T> responseFunc) where T : ResponseBase
        {
            switch (request.ResponseType)
            {
                case ResponseType.Xml:
                    return GetResultXml(responseFunc());
                case ResponseType.Json:
                    return GetResultJson(responseFunc());
                default:
                    throw new InvalidOperationException(string.Format("Unknown result type:'{0}'.", request.ResponseType));
            }
        }

        private static string GetResultJson<T>(T response) where T : ResponseBase
        {
            return JsonConvert.SerializeObject(response);
        }

        private static string GetResultXml<T>(T response) where T : ResponseBase
        {
            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                var serializer = new XmlSerializer(typeof(T)); // Можно кэшировать сериализаторы для дополнительной производительности, но в т.з. таких требований нет
                serializer.Serialize(stringWriter, response);
            }

            return stringBuilder.ToString();
        }
    }
}
