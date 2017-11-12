using System.Configuration;
using LoginetWebApp.Abstract;

namespace LoginetWebApp.Impl
{
    public class Options
        : IOptions
    {
        private Options()
        {
        }

        public string DataSourceUri { get; private set; }

        public static Options Create()
        {
            var options = new Options();

            options.DataSourceUri = ConfigurationManager.AppSettings["DataSourceUri"];

            return options;
        }
    }
}