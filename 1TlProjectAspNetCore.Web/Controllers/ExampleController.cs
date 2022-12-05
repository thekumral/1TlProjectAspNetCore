using Microsoft.AspNetCore.Mvc;

namespace _1TlProjectAspNetCore.Web.Controllers
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ExampleController : Controller
    {
        
        public IActionResult Index()
        {
            ViewBag.name = "Asp.NetCore Project example";
            ViewData["age"] = 31;
            ViewData["names"] = new List<string>() { "ömer", "ruveyda", "cabbar" };
            ViewBag.person = new { Id = 1, Name = "Ömer", Age = "21", Price = 4444 };

            var productList = new List<Products>()
            {
                new(){Id=1,Name="kalem"},
                new(){Id=2,Name="Silgi"},
                new(){Id=3,Name="uç"}
            };
            return View(productList);
        }
        public IActionResult ContentResult()
        {
            return Content("Content Result");
        }
        public IActionResult JsonResult() {
            return Json(new { id = 1, name = "Ömer", price = 100 });
        }
        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }
        public IActionResult Index2(int id)
        {
            return RedirectToAction("index","example");
            
        }
        public IActionResult ParameterView(int id)
        {
            return RedirectToAction("JsonResultParameter", "example", new{id = id});
        }
        public IActionResult JsonResultParameter(int id) 
        {
            return Json(new { Id = id});
        }
        public IActionResult IndexTd() 
        {
            return RedirectToAction("index", "example");
        }
    }
}
