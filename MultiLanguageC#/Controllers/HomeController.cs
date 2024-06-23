using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using MultiLanguageC_.Models;
using MultiLanguageC_.Services;
using System.Diagnostics;

namespace MultiLanguageC_.Controllers
{
    public class HomeController : Controller
    {
        private readonly LocalizationService _localizationService;

        public HomeController(LocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        public IActionResult Index()
        {
           
            var culture = HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name ?? "en-US";

            
            var welcomeMessage = _localizationService.GetResource(culture, "HomePage_Title");

            
            ViewBag.WelcomeMessage = welcomeMessage;
            ViewBag.CurrentCulture = culture;
            return View();
        }
        [HttpGet]
        public IActionResult SetLanguage(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            string returnUrl = Request.Headers["Referer"].ToString();
            return Redirect(returnUrl);
        }
        public IActionResult Privacy()
        {

            var culture = HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name ?? "en-US";


            var welcomeMessage = _localizationService.GetResource(culture, "HomePage_Title");


            ViewBag.WelcomeMessage = welcomeMessage;
            ViewBag.CurrentCulture = culture;
            return View();
        }


    }
}
