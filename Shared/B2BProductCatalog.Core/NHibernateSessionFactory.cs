using System;
using System.Web;
using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Context;

namespace B2BProductCatalog.Core
{
    public class NHibernateSessionFactory : IHttpModule
    {
        private static readonly ISessionFactory _sessionFactory;

        public static ISession Session
        {
            get { return GetCurrentSession(); }
        }

        static NHibernateSessionFactory()
        {
            _sessionFactory = CreateSessionFactory();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
            context.EndRequest += EndRequest;
        }

        public void Dispose()
        {
            if (!_sessionFactory.IsClosed)
                _sessionFactory.Close();
        }

        private static ISession GetCurrentSession()
        {
            if (!CurrentSessionContext.HasBind(_sessionFactory))
                CurrentSessionContext.Bind(_sessionFactory.OpenSession());
            
            return _sessionFactory.GetCurrentSession();
        }

        private static void BeginRequest(object sender, EventArgs e)
        {
            ISession session = _sessionFactory.OpenSession();
            session.BeginTransaction();
            CurrentSessionContext.Bind(session);
        }

        private static void EndRequest(object sender, EventArgs e)
        {
            ISession session = CurrentSessionContext.Unbind(_sessionFactory);

            if (session == null) return;

            try
            {
                session.Transaction.Commit();
            }
            catch (Exception)
            {
                session.Transaction.Rollback();
            }
            finally
            {
                session.Close();
                session.Dispose();
            }
        }
        
        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(c => c.FromConnectionStringWithKey("B2BProductCatalogDB")))
                .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<B2BExtract>()
                    .AddFromAssemblyOf<Brand>()
                    .AddFromAssemblyOf<Brand_Locale>()
                    .AddFromAssemblyOf<FlagCategory>()
                    .AddFromAssemblyOf<FlagCategory_Locale>()
                    .AddFromAssemblyOf<Flag>()
                    .AddFromAssemblyOf<Flag_Locale>()
                    .AddFromAssemblyOf<Locale>()
                    .AddFromAssemblyOf<Navigation>()
                    .AddFromAssemblyOf<Navigation_Locale>()
                    .AddFromAssemblyOf<Pattern>()
                    .AddFromAssemblyOf<Pattern_Locale>()
                    .AddFromAssemblyOf<Style>()
                    .AddFromAssemblyOf<Style_Locale>()
                    .AddFromAssemblyOf<User>()
                    .Conventions.Add(AutoImport.Never(),
                                     DefaultCascade.All(),
                                     DefaultLazy.Always(),
                                     DynamicInsert.AlwaysTrue(),
                                     DynamicUpdate.AlwaysTrue(),
                                     OptimisticLock.Is(x => x.Dirty()),
                                     ForeignKey.EndsWith("Id")))
                .BuildSessionFactory();
        }
    }
}
