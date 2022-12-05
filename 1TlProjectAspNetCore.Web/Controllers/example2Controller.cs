using Microsoft.AspNetCore.Mvc;

namespace _1TlProjectAspNetCore.Web.Controllers
{
    public class example2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NoLayout() 
        {
            return View();
        }
    }
}
