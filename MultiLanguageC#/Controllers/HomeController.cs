using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using MultiLanguageC_.Connect;
using MultiLanguageC_.Models;
using MultiLanguageC_.Services;
using System.Diagnostics;

namespace MultiLanguageC_.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly LanguageDbContext _db;

        public HomeController(LocalizationService localizationService,LanguageDbContext db, LanguageService languageService)
        {
         
            _db = db;   
        }

        public IActionResult Index()
        {

           
         List<Customers> model=_db.Customers.ToList();
            

            return View(model);
        }

        [HttpGet]
        public IActionResult SetLanguage(string culture)
        {
            
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) }
            );

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
    }


}
