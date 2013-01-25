using System;
using System.Collections.Generic;
using B2BProductCatalog.Core.Entities;
using System.Collections;
using NHibernate.Criterion;

namespace B2BProductCatalog.Core.Repositories
{
    public interface IUserRepository
    {
        User GetUserByName(string userName);
        string GetUserNameByEmail(string email);
        User GetUserById(int userId);
        void SaveUser(User userToSave);
        void DeleteUser(User userToDelete);
        IEnumerable<User> GetAllUsers(int pageIndex, int pageSize);
        IEnumerable<User> FindUsersByEMail(string email, int pageIndex, int pageSize);
        IEnumerable<User> FindUsersByName(string userName, int pageIndex, int pageSize);
        int GetNumberOfUsersOnline(DateTime lastActivityDate);
    }
    
    public class UserRepository : IUserRepository
    {
        public UserRepository() { }

        #region IUserRepository Members

        public User GetUserByName(string userName)
        {
            return NHibernateSessionFactory.Session.CreateCriteria(typeof(User))
                        .Add(Restrictions.Eq("Username", userName))
                        .UniqueResult() as User;
        }

        public void SaveUser(User userToSave)
        {
            NHibernateSessionFactory.Session.SaveOrUpdate(userToSave);
        }

        public void DeleteUser(User userToDelete)
        {
            NHibernateSessionFactory.Session.Delete(userToDelete);
        }

        public IEnumerable<User> GetAllUsers(int pageIndex, int pageSize)
        {
            return NHibernateSessionFactory.Session.CreateCriteria(typeof(User))
                        .SetFirstResult(pageIndex * pageSize).SetMaxResults(pageSize)
                        .List<User>() as List<User>;
        }

        public int GetNumberOfUsersOnline(DateTime lastActivityDate)
        {
            IList uList = NHibernateSessionFactory.Session.CreateCriteria(typeof(User))
                        .Add(Expression.Ge("LastActivityDate", lastActivityDate))
                        .List();
            return uList.Count;
        }

        public User GetUserById(int userId)
        {
            return NHibernateSessionFactory.Session.Get<User>(userId);
        }


        public string GetUserNameByEmail(string email)
        {
            IList uList = NHibernateSessionFactory.Session.CreateCriteria(typeof(User))
                .Add(Expression.Eq("Email", email))
                .List();
            if (uList.Count > 0)
            {
                User u = (User)uList[0];
                return u.Username;
            }
            return String.Empty;  
        }

        public IEnumerable<User> FindUsersByEMail(string email, int pageIndex, int pageSize)
        {
            return NHibernateSessionFactory.Session.CreateCriteria(typeof (User))
                       .Add(Expression.Like("EMail", email, MatchMode.Anywhere))
                       .SetFirstResult(pageIndex*pageSize).SetMaxResults(pageSize)
                       .List<User>() as List<User>;
        }

        public IEnumerable<User> FindUsersByName(string userName, int pageIndex, int pageSize)
        {
            return NHibernateSessionFactory.Session.CreateCriteria(typeof (User))
                       .Add(Expression.Like("Username", userName, MatchMode.Anywhere))
                       .SetFirstResult(pageIndex*pageSize).SetMaxResults(pageSize)
                       .List<User>() as List<User>;
        }

        #endregion
    }
}
