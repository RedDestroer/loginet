using System.Configuration;
using LoginetWebApp.Abstract;

namespace LoginetWebApp.Impl
{
    /// <summary>
    /// Настройки сервиса
    /// </summary>
    public class Options
        : IOptions
    {
        private Options()
        {
        }

        /// <summary>
        /// Корень, откуда обращаться к веб-сервису с базой данных
        /// </summary>
        public string DataSourceUri { get; private set; }

        /// <summary>
        /// Создание настроек
        /// </summary>
        /// <returns></returns>
        public static Options Create()
        {
            var options = new Options();

            options.DataSourceUri = ConfigurationManager.AppSettings["DataSourceUri"];

            return options;
        }
    }
}