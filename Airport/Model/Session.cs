using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    public static class Session
    {
        static ISessionFactory factory;
        

        public static ISession OpenSession()
        {
            if (factory == null)
            {
                Configuration c = new Configuration();
                c.Configure();
                c.AddAssembly(typeof(Firm).Assembly);
                new SchemaExport(c).Execute(true, true, false);
                //c.AddAssembly(Assembly.GetCallingAssembly());
                factory = c.BuildSessionFactory();
            }

            return factory.OpenSession();
        }
    }
}
