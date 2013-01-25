using System.Collections.Generic;
using B2BProductCatalog.Core.Entities;
using NHibernate.Criterion;

namespace B2BProductCatalog.Core.Repositories
{
    public interface IBrandRapository
    {
        IEnumerable<Brand> GetListOfBrands();
        Brand GetByBrandId(int id);
        Brand GetBySODC(string salesOrg, string distChan);
        List<B2BExtract> GetSAPExtractDataByBrand(Brand brand);
    }
    
    public class BrandRepository : IBrandRapository
    {
        public BrandRepository() { }
        
        public IEnumerable<Brand> GetListOfBrands()
        {
            return NHibernateSessionFactory.Session.CreateCriteria(typeof(Brand))
                .List<Brand>() as List<Brand>;
        }

        public Brand GetByBrandId(int id)
        {
            return NHibernateSessionFactory.Session.Get<Brand>(id);
        }

        //TODO: Probably won't ever need this
        public Brand GetBySODC(string salesOrg, string distChan)
        {
            var brandLocale = NHibernateSessionFactory.Session.CreateCriteria(typeof(Brand_Locale))
                        .Add(Restrictions.Eq("SalesOrg", salesOrg))
                        .Add(Restrictions.Eq("DistChan", distChan))
                        .UniqueResult() as Brand_Locale;

            return brandLocale == null ? null : brandLocale.Brand;
        }

        public List<B2BExtract> GetSAPExtractDataByBrand(Brand brand)
        {
            var extract = NHibernateSessionFactory.Session.CreateCriteria(typeof (B2BExtract))
                              .Add(Restrictions.Eq("SalesOrg", brand.BrandInfos[0].SalesOrganization))
                              .Add(Restrictions.Eq("DistChan", brand.BrandInfos[0].DistributionChannel))
                              .List<B2BExtract>() as List<B2BExtract>;

            return extract;
        }
    }
}