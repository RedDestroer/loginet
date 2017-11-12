using System.ComponentModel;
using System.Configuration;
using IContainer = LoginetWebApp.Abstract.IContainer;

namespace LoginetWebApp.Impl
{
    public class Config
    {
        private static volatile object _syncRoot = new object();
        private static IContainer _instance;

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