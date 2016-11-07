using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace TestFramework
{
    public static class Log
    {
        static Log()
        {
            XmlConfigurator.Configure();
        }
        public static ILog For(object LoggedObject)
        {
            return For(LoggedObject.GetType());
        }

        public static ILog For(Type ObjectType)
        {
            return LogManager.GetLogger(ObjectType.Name);
        }
    }
}
