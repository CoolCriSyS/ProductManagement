using System;
using System.Collections.Generic;
using B2BProductCatalog.Core.Entities;
using NHibernate.Criterion;

namespace B2BProductCatalog.Core.Repositories
{
    public interface IPatternRepository
    {
        Pattern GetPatternByName(string patternName);
        void SavePattern(Pattern patternToSave);
        void DeletePattern(Pattern patternToDelete);
        List<Pattern> GetAllPatternsByBrand(int brandId);
        Locale GetLocaleById(int localeId);
        Navigation GetNavigationForPattern(int patternId);
        List<Style> GetStylesForPattern(int patternId);
        Style GetStyle(string stockNumber);
        B2BExtract GetSAPInfoByStockNumber(string stockNumber);
    }
    
    public class PatternRepository : IPatternRepository
    {
        public PatternRepository() { }

        public Pattern GetPatternByName(string patternName)
        {
            var patternLocale = NHibernateSessionFactory.Session.CreateCriteria(typeof(Pattern_Locale))
                    .Add(Restrictions.Like("Name", patternName))
                    .UniqueResult() as Pattern_Locale;
            
            return patternLocale == null ? null : patternLocale.Pattern;
        }

        /// <summary>
        /// Saves a pattern to the database.
        /// NOTE: Populate the PatternInfos property before calling this.
        /// </summary>
        public void SavePattern(Pattern patternToSave)
        {
            NHibernateSessionFactory.Session.SaveOrUpdate(patternToSave);
        }

        /// <summary>
        /// Shouldn't ever really need to use this but just in case.
        /// </summary>
        public void DeletePattern(Pattern patternToDelete)
        {
            NHibernateSessionFactory.Session.Delete(patternToDelete);
        }
        
        /// <summary>
        /// Use BrandEnum for corresponding BrandId
        /// </summary>
        public List<Pattern> GetAllPatternsByBrand(int brandId)
        {
            var patterns = NHibernateSessionFactory.Session.CreateCriteria(typeof(Pattern))
                        .Add(Restrictions.Eq("Brand.Id", brandId))
                        .List<Pattern>() as List<Pattern>;

            foreach (var pattern in patterns)
            {
                var styles = NHibernateSessionFactory.Session.CreateCriteria(typeof(Style))
                        .Add(Restrictions.Eq("Pattern.Id", pattern.Id))
                        .List<Style>() as List<Style>;

                pattern.Styles = styles;
            }

            return patterns;
        }

        public Locale GetLocaleById(int localeId)
        {
            return NHibernateSessionFactory.Session.CreateCriteria(typeof (Locale))
                .Add(Restrictions.Eq("Id", localeId))
                .UniqueResult() as Locale;
        }

        public Navigation GetNavigationForPattern(int patternId)
        {
            throw new NotImplementedException();
        }

        public List<Style> GetStylesForPattern(int patternId)
        {
            throw new NotImplementedException();
        }

        public Style GetStyle(string styleNumber)
        {
            var styles = NHibernateSessionFactory.Session.CreateCriteria(typeof(Style))
                .Add(Restrictions.Eq("StyleNumber", styleNumber))
                .List<Style>();

            //TODO: Do I need this?
            //var styleInfos = NHibernateSessionFactory.Session.CreateCriteria(typeof(Style_Locale))
            //    .Add(Restrictions.Eq("Style.Id", styles[0].Id))
            //    .List<Style_Locale>();

            //foreach (var styleLocale in styleInfos)
            //{
            //    styles[0].StyleInfos.Add(styleLocale);
            //}

            return styles == null ? null : styles[0];
        }

        public B2BExtract GetSAPInfoByStockNumber(string stockNumber)
        {
            var extract = NHibernateSessionFactory.Session.CreateCriteria(typeof(B2BExtract))
                        .Add(Restrictions.Like("StockNumber", stockNumber))
                        .UniqueResult() as B2BExtract;

            return extract;
        }
    }
}