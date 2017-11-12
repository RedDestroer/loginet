using System.Web;
using LoginetWebApp.Abstract;

namespace LoginetWebApp.Impl
{
    /// <summary>
    /// Контейнер, заменяющий IOC, чтобы не цеплять лишних зависимостей
    /// </summary>
    public class Container
        : IContainer
    {
        private readonly IOptions _options;
        private readonly IDataSource _dataSource;

        public Container()
        {
            _options = Options.Create();
            _dataSource = new DataSource(_options.DataSourceUri);
        }

        /// <summary>
        /// Источник данных для сервиса
        /// </summary>
        /// <returns></returns>
        public IDataSource ResolveDataSource()
        {
            return _dataSource;
        }

        /// <summary>
        /// Настройки сервиса
        /// </summary>
        /// <returns></returns>
        public IOptions ResolveoOptions()
        {
            return _options;
        }
    }
}