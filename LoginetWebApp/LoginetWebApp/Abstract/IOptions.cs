namespace LoginetWebApp.Abstract
{
    /// <summary>
    /// Настройки сервиса
    /// </summary>
    public interface IOptions
    {
        /// <summary>
        /// Корень, откуда обращаться к веб-сервису с базой данных
        /// </summary>
        string DataSourceUri { get; }
    }
}