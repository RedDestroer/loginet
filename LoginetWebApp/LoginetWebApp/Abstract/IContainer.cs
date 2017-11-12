namespace LoginetWebApp.Abstract
{
    /// <summary>
    /// Контейнер, заменяющий IOC, чтобы не цеплять лишних зависимостей
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Источник данных для сервиса
        /// </summary>
        /// <returns></returns>
        IDataSource ResolveDataSource();

        /// <summary>
        /// Настройки сервиса
        /// </summary>
        /// <returns></returns>
        IOptions ResolveoOptions();
    }
}