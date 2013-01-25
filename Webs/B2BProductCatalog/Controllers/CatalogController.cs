using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using B2BProductCatalog.Core.Entities;
using B2BProductCatalog.Core.Repositories;
using B2BProductCatalog.Models;
using NHibernate;

namespace B2BProductCatalog.Controllers
{
    [HandleError]
    public class CatalogController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult CatalogBuilder()
        {
            var model = new CatalogBuilderModel
                        {
                            Gender = GetGenders(),
                            Products = GetProducts()
                        };

            return View(model);
        }

        private static IEnumerable<SelectListItem> GetGenders()
        {
            var item0 = new SelectListItem { Text = "Men", Value = "Men"};
            var item1 = new SelectListItem { Text = "Women", Value = "Women" };
            var item2 = new SelectListItem { Text = "Kids", Value = "Kids" };

            return new List<SelectListItem> { item0, item1, item2 };
        }

        private List<Pattern> GetProducts()
        {
            IPatternRepository patternRepo = new PatternRepository();
            IUserRepository userRepo = new UserRepository();

            var user = userRepo.GetUserByName(User.Identity.Name);

            return patternRepo.GetAllPatternsByBrand(user.Brand.Id);
        }

        [HttpPost]
        public ActionResult CatalogBuilder(CatalogBuilderModel model)
        {
            if (ModelState.IsValid)
            {
                IPatternRepository patternRepo = new PatternRepository();
                IUserRepository userRepo = new UserRepository();
                
                var user = userRepo.GetUserByName(User.Identity.Name);

                int stylesAdded = 0;
                string notFound = string.Empty;

                foreach (var stockNumber in model.StockNumbers)
                {
                    var extract = patternRepo.GetSAPInfoByStockNumber(stockNumber);
                    if (extract == null)
                    {
                        notFound += stockNumber + ", ";
                        continue;
                    }

                    Style style = patternRepo.GetStyle(stockNumber);
                    if (style != null)
                    {
                        //TODO: If style exists, we need to load it and update the data?
                        //If SAP data is updated, do we need to update? Yes.
                        continue;
                    }
                    var locale = patternRepo.GetLocaleById(1);
                    var navigation = new Navigation
                                         {
                                             Brand = user.Brand
                                         };

                    // Populate a Pattern, Navigation, Style, etc. and save.
                    var pattern = !string.IsNullOrEmpty(extract.PatternName) ?
                        patternRepo.GetPatternByName(extract.PatternName) :
                        new Pattern { Brand = user.Brand, Navigation = navigation };

                    pattern.PatternInfos.Add(new Pattern_Locale
                                                 {
                                                     Name = extract.StyleName, Locale = locale,
                                                     SAPPatternId = extract.PatternId, PatternLabel1 = extract.PatternLabel1,
                                                     PatternLabel2 = extract.PatternLabel2, Pattern = pattern,
                                                     Keywords = !string.IsNullOrEmpty(extract.PatternName) ? string.Format("{0} {1}", extract.PatternName, extract.PatternDesc) : null
                                                 });
                    // For navigation, try using SAP hierarchy if available
                    // HyTest is unique
                    pattern.Navigation.NavigationInfos.Add(new Navigation_Locale
                                                                {
                                                                    Category1 = extract.BrandName, Category2 = extract.DivisionDesc,
                                                                    Category3 = extract.Hierarchy2Desc ?? extract.Hierarchy1Desc ?? extract.GenderDesc, 
                                                                    Category4 = extract.PatternName ?? extract.StyleName,
                                                                    Navigation = pattern.Navigation, Locale = locale
                                                                });
                    pattern.Styles.Add(new Style
                                            {
                                                StyleNumber = extract.StockNumber, Pattern = pattern
                                            });
                    pattern.Styles[0].StyleInfos.Add(new Style_Locale
                                                            {
                                                                BoxLabelColor = extract.BoxLabelColor, Color = extract.Color ?? extract.StyleName,
                                                                DefaultPlant = extract.DefaultPlant, DistChan = extract.DistributionChannel,
                                                                Division = extract.Division, DivisionDesc = extract.DivisionDesc, 
                                                                GenderDesc = extract.GenderDesc, GenderId = extract.GenderId,
                                                                Inventory = extract.Inventory, Locale = locale, Description = extract.StyleName,
                                                                MaterialCreated = extract.MaterialCreated, POQuantity = extract.POQuantity, 
                                                                SalesOrg = extract.SalesOrganization, Season = extract.Season, 
                                                                Status = extract.Status, UofM = extract.UofM, Style = pattern.Styles[0]
                                                            });
                    
                    patternRepo.SavePattern(pattern);
                    stylesAdded++;
                }

                ViewData["NotFound"] = "Styles not found: " + notFound;
                ViewData["StylesAdded"] = "Styles added: " + stylesAdded;
            }

            
            //TODO: Show more info in the table. Add controls to edit/remove? Sounds like Dan said no to this.

            model.Gender = GetGenders();
            model.Products = GetProducts();

            return View(model);
        }

        public ActionResult Technologies()
        {
            return View();
        }

        public ActionResult NavBuilder()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }

    public class SessionController : Controller
    {
        public HttpSessionStateBase HttpSession
        {
            get { return base.Session; }
        }

        public new ISession Session { get; set; }
    }
}
