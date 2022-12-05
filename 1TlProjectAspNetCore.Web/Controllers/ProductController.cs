using _1TlProjectAspNetCore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1TlProjectAspNetCore.Web.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;
        private readonly ProductRepository _productRepository;
        public ProductController(AppDbContext context)
        {
            _productRepository = new ProductRepository();

            _context = context;
            // any herhangi bi kayıt yoksa kayıt et çalış yani LINQ methodu
            if (!_context.Products.Any())
            {
                _context.Products.Add(new Product() { Name = "Kalem 1", Price = 100, Stock = 100 ,Color="Red",Width=300,Height=250});
                _context.Products.Add(new Product() { Name = "Kalem 2", Price = 200, Stock = 200, Color = "Blue", Width = 300, Height = 250 });
                _context.Products.Add(new Product() { Name = "Kalem 3", Price = 200, Stock = 300, Color = "Green", Width = 300, Height = 250 });

                _context.SaveChanges(); // memory de çalışan verileri satır oluştur.
            }
            



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
            //tolist LINQ methodudur.
            var products = _context.Products.ToList();
            var product = _context.Products.First();

            //has value => değer var mı yokmu null mı true false
            //value => değeri almak için
            //product.Width.HasValue;
            //var a = product.Width.Value

            return View(products);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Update(int id) 
        {
            return View();
        }
        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
