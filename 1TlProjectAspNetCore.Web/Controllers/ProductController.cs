using _1TlProjectAspNetCore.Web.Helper;
using _1TlProjectAspNetCore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1TlProjectAspNetCore.Web.Controllers
{
    public class ProductController : Controller
    { 
        private AppDbContext _context;
        private readonly ProductRepository _productRepository;
        public ProductController(AppDbContext context,IHelper helper)
        {
            _productRepository = new ProductRepository();
            _context = context;
            // any herhangi bi kayıt yoksa kayıt et çalış yani LINQ methodu
            //if (!_context.Products.Any())
            //{
            //    _context.Products.Add(new Product() { Name = "Kalem 1", Price = 100, Stock = 100 ,Color="Red"});
            //    _context.Products.Add(new Product() { Name = "Kalem 2", Price = 200, Stock = 200, Color = "Blue"  });
            //    _context.Products.Add(new Product() { Name = "Kalem 3", Price = 200, Stock = 300, Color = "Green" });

            //    _context.SaveChanges(); // memory de çalışan verileri satır oluştur.
            //}
            



            //context uygulama ayağa kalktığında bi classın constructer ında appdbcontext nesnesini görürse nesne örneği üretip verilıyo ondan nesne tanımlaması kullanmıyoruz 
            // bunada dependency injection design pattern aracılığıyla nesne alınır
            //bağımlılıkların kontrol edilmesi çözümlenmesi classın ihtiyaç duyduğu data-class ları almayı sağlar Dı container aracılığı ile
            // DI container constructerda nesne örneği alma muhabbeti işte

            //if (!_productRepository.GetAll().Any())
            //{
            //    }
        }
        //ctor constructure kısaltma
        public IActionResult Index()
        {
         
            var products = _context.Products.ToList();
            //var product = _context.Products.First();

            //has value => değer var mı yokmu null mı true false
            //value => değeri almak için
            //product.Width.HasValue;
            //var a = product.Width.Value

            return View(products);
        }
        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id) 
        {
            var product = _context.Products.Find(id);

            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product updateProduct,int productId,string type)
        {
            updateProduct.Id= productId;
            _context.Products.Update(updateProduct);
            _context.SaveChanges();


            TempData["status"] = "Ürün başarıyla güncellendi";


            return RedirectToAction("index");
        }
        [HttpGet] //sayfayı göstermek için yapar
        public IActionResult Add()
        {
            return View();
        }
        //buton ile data kaydetme post SADECE GETLERİN SAYFASI olur
        //request Head-body var post body den gelir bu daha güvenlikli
        //get kısmı iste url yani request ın head ında gelir
        //get kısmı iste url yani request ın head ında gelir
        // buna gerek kalmadı=>/*string Name,decimal Price,int Stock,string Color*/ bu new product yerindeydi
        [HttpPost]
        public IActionResult Add(Product newproduct)
        {
            //1. yöntem
            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse( HttpContext.Request.Form["Price"]);
            //var stock = int.Parse( HttpContext.Request.Form["Stock"]);
            //var color = HttpContext.Request.Form["Color"].ToString();

            //Product newProduct=new Product() { Name=Name,Price=Price,Stock=Stock,Color=Color};

            _context.Products.Add(newproduct);
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla eklendi";
            return RedirectToAction("index");
        }
        //[HttpGet]
        //public IActionResult SaveProduct(Product newproduct)
        //{
        //    //1. yöntem
        //    //var name = HttpContext.Request.Form["Name"].ToString();
        //    //var price = decimal.Parse( HttpContext.Request.Form["Price"]);
        //    //var stock = int.Parse( HttpContext.Request.Form["Stock"]);
        //    //var color = HttpContext.Request.Form["Color"].ToString();

        //    //Product newProduct=new Product() { Name=Name,Price=Price,Stock=Stock,Color=Color};
        //    _context.Products.Add(newproduct);
        //    _context.SaveChanges();
        //    return View();
        //}

    }
}
