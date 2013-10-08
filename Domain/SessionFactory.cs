using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Data;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace CSEsMS.Domain
{
    public class SessionFactory
    {
        public static ISessionFactory CreateSessionFactory()
        {
  //          return Fluently.Configure()
  //              .Database(MsSqlConfiguration.MsSql2008
  //.ConnectionString(@"Data Source=.\SqlExpress;Initial Catalog=CSEsMS;Trusted_Connection=true;"))
  //              .Mappings(m =>
  //                  m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
  //              .ExposeConfiguration(BuildSchema)
  //              .BuildSessionFactory();

            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                              .ConnectionString(
                              @"Data Source=.\SqlExpress;Initial Catalog=CSEsMS;Trusted_Connection=true;"))
                .Mappings(m =>
                          m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }

        public static ISessionFactory CreateSessionFactoryBuildSchema()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                              .ConnectionString(
                              @"Data Source=.\SqlExpress;Initial Catalog=CSEsMS;Trusted_Connection=true;"))
                .Mappings(m =>
                          m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        public static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            //if (File.Exists(DbFile))
            //    File.Delete(DbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }
    }
}
