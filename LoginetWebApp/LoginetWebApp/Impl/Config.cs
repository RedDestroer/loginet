using System.ComponentModel;
using System.Configuration;
using IContainer = LoginetWebApp.Abstract.IContainer;

namespace LoginetWebApp.Impl
{
    /// <summary>
    /// Точка конфигурирования приложения. Серьёзных IOC тут не надо, по-этому достаточно singletone с контейнером приложения
    /// </summary>
    public class Config
    {
        private static volatile object _syncRoot = new object();
        private static IContainer _instance;

        /// <summary>
        /// Контейнер с необходимыми для работы сервиса классами
        /// </summary>
        public static IContainer Container
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new Container();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}