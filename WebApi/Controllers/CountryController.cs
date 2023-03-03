using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
