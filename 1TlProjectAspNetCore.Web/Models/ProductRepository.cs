using _1TlProjectAspNetCore.Web.Models;
using System.Drawing;

namespace _1TlProjectAspNetCore.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new() { Id = 1, Name = "kalem 1", Price = 100, Stock = 100,Color="Red"},
            new () { Id = 2, Name = "kalem 2", Price = 200, Stock = 200,Color="Blue",},
            new () { Id = 3, Name = "kalem 3", Price = 300, Stock = 300 ,Color="Green",},
            new() { Id = 4, Name = "kalem 4", Price = 400, Stock = 400,Color="black",}

        };

        public List<Product> GetAll() => _products;
        public void Add(Product newProduct)=> _products.Add(newProduct);

        //public void Adds(Product NewProductS)
        //{                             => işlevi burda bunu yapar
        //     _products.Add(NewProductS);
        //}
        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == id);
            if (hasProduct == null)
            {
                throw new Exception($"Bu id({id})'ye sahip ürün bulunmamaktadir.");
            }
            _products.Remove(hasProduct);
        }
        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id);
            if (hasProduct == null) 
            {
                throw new Exception($"Bu id({updateProduct.Id})'ye sahip ürün bulunmamaktadır.");
            }
            hasProduct.Name= updateProduct.Name;
            hasProduct.Price= updateProduct.Price;
            hasProduct.Stock= updateProduct.Stock;


            var index = _products.FindIndex(x => x.Id == updateProduct.Id);

            _products[index] = hasProduct;
        }
    }
}
