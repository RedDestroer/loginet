using System.Web;
using LoginetWebApp.Abstract;

namespace LoginetWebApp.Impl
{
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

        public IDataSource ResolveDataSource()
        {
            return _dataSource;
        }

        public IOptions ResolveoOptions()
        {
            return _options;
        }
    }
}