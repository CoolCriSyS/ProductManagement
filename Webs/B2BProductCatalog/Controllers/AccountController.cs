using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using B2BProductCatalog.Core.Repositories;
using B2BProductCatalog.Models;

namespace B2BProductCatalog.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        private IFormsAuthenticationService FormsService { get; set; }
        private IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    
                    return RedirectToAction("Index", "Catalog");
                }
                
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Catalog");
        }

        public ActionResult Register()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;

            var model = new RegisterModel { Brands = GetBrands() };

            return View(model);
        }

        private static IEnumerable<SelectListItem> GetBrands()
        {
            IBrandRapository brandRepo = new BrandRepository();

            return brandRepo.GetListOfBrands().Select(brand => new SelectListItem
                                                                {
                                                                    Text = brand.Name, 
                                                                    Value = brand.Id.ToString()
                                                                }).ToList();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var brandRepo = new BrandRepository();
                var brand = brandRepo.GetByBrandId(model.BrandId);

                if (brand.Password != model.BrandPassword)
                {
                    ModelState.AddModelError("", "Incorrect brand password");
                }
                else
                {
                    // Attempt to register the user
                    var createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email, model.BrandId);

                    if (createStatus == MembershipCreateStatus.Success)
                    {
                        FormsService.SignIn(model.UserName, false);
                        return RedirectToAction("Index", "Catalog");
                    }

                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            model.Brands = GetBrands();

            return View(model);
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
    }
}
