using System.Collections.Generic;
using LoginetWebApp.Domain;

namespace LoginetWebApp.Abstract
{
    /// <summary>
    /// Источник данных для сервиса
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Возвращает список пользователей
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetUsers();

        /// <summary>
        /// Возвращает пользователя по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUser(int id);

        /// <summary>
        /// Возвращает список альбомов
        /// </summary>
        /// <returns></returns>
        IEnumerable<Album> GetAlbums();

        /// <summary>
        /// Возвращает альбом по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Album GetAlbum(int id);
    }
}