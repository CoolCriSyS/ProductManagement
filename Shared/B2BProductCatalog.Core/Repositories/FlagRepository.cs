using System.Collections.Generic;
using B2BProductCatalog.Core.Entities;
using NHibernate.Criterion;

namespace B2BProductCatalog.Core.Repositories
{
    public interface IFlagRepository
    {
        Flag GetByFlagName(string flagName);
        FlagCategory GetByFlagCategoryName(string categoryName);
        void SaveFlagInfo(Flag flagToSave);
        void SaveFlagCategoryInfo(FlagCategory flagCategoryInfoToSave);
        IEnumerable<Flag> GetAllFlagsByBrand(int brandId);
        IEnumerable<FlagCategory> GetAllFlagCategoriesByBrand(int brandId);
        void DeleteFlag(Flag flagToDelete);
        void DeleteFlagCategory(FlagCategory flagCategoryToDelete);
    }
    
    public class FlagRepository : IFlagRepository
    {
        public FlagRepository() { }

        public Flag GetByFlagName(string flagName)
        {
            var flagInfoLocale = NHibernateSessionFactory.Session.CreateCriteria(typeof(Flag_Locale))
                        .Add(Restrictions.Eq("Name", flagName))
                        .UniqueResult() as Flag_Locale;

            return flagInfoLocale == null ? null : flagInfoLocale.Flag;
        }

        public FlagCategory GetByFlagCategoryName(string categoryName)
        {
            var flagCategoryLocale = NHibernateSessionFactory.Session.CreateCriteria(typeof(FlagCategory_Locale))
                        .Add(Restrictions.Eq("Name", categoryName))
                        .UniqueResult() as FlagCategory_Locale;

            if (flagCategoryLocale == null) return null;

            return flagCategoryLocale.FlagCategory;
        }

        public void SaveFlagInfo(Flag flagToSave)
        {
            NHibernateSessionFactory.Session.SaveOrUpdate(flagToSave);
        }

        public void SaveFlagCategoryInfo(FlagCategory flagCategoryInfoToSave)
        {
            NHibernateSessionFactory.Session.SaveOrUpdate(flagCategoryInfoToSave);
        }

        public IEnumerable<Flag> GetAllFlagsByBrand(int brandId)
        {
            return NHibernateSessionFactory.Session.CreateCriteria(typeof(Flag))
                        .Add(Restrictions.Eq("Brand.Id", brandId))
                        .List<Flag>() as List<Flag>;

                    //TODO: Will this load the corresponding FlagInfo_Locales?
        }

        public IEnumerable<FlagCategory> GetAllFlagCategoriesByBrand(int brandId)
        {
            return NHibernateSessionFactory.Session.CreateCriteria(typeof(FlagCategory))
                        .Add(Restrictions.Eq("Brand.Id", brandId))
                        .List<FlagCategory>() as List<FlagCategory>;

                    //TODO: Will this load the corresponding FlagCategory_Locales?
        }

        public void DeleteFlag(Flag flagToDelete)
        {
            NHibernateSessionFactory.Session.Delete(flagToDelete);
        }

        public void DeleteFlagCategory(FlagCategory flagCategoryToDelete)
        {
            NHibernateSessionFactory.Session.Delete(flagCategoryToDelete);
        }
    }
}