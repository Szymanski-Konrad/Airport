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
                //c.AddAssembly(Assembly.GetCallingAssembly());
                new SchemaExport(c).Execute(true, true, false);
                //new SchemaExport(c).Create(true, true);
                //new SchemaExport(c).Drop(false, false);
                factory = c.BuildSessionFactory();
            }

            return factory.OpenSession();
        }
    }
}
