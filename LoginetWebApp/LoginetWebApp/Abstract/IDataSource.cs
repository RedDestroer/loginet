using System.Collections.Generic;
using LoginetWebApp.Domain;

namespace LoginetWebApp.Abstract
{
    public interface IDataSource
    {
        /// <summary>
        /// Возвращает список пользователей
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetUsers();

        /// <summary>
        /// Возвращает список альбомов
        /// </summary>
        /// <returns></returns>
        IEnumerable<Album> GetAlbums();
    }
}