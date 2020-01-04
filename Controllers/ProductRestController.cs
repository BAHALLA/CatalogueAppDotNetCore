using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections;
using CatalogueApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CatalogueApp.Controllers {

    [Route("/api/products")]
    public class ProductRestController: Controller {
        
        private CatalogueDbRepository CatalogueDb { get; set; }

        public ProductRestController(CatalogueDbRepository catalogueContext) {
            this.CatalogueDb = catalogueContext;

        }

        [HttpGet]
        public IEnumerable<Product> FindAll() {
            return CatalogueDb.products.Include( p => p.Category);
        }
        [HttpGet("{id}")]
        public Product FindOne(long id) {
            return CatalogueDb.products.Include( p => p.Category).FirstOrDefault(p=>p.ProductID ==id);
        }
        [HttpGet("search")]
        public IEnumerable<Product> Search(string kw) {
            return CatalogueDb
            .products
            .Include( p => p.Category)
            .Where( p => p.Name.Contains(kw));
        }
         [HttpGet("paginate")]
        public IEnumerable<Product> Paginate(int page =1, int size = 2) {
            int skipValue = (page - 1) * size;
            return CatalogueDb
            .products
            .Include( p => p.Category)
            .Skip(skipValue)
            .Take(size);
        }



         [HttpPost]
        public Product Save([FromBody] Product product) {
             CatalogueDb.products.Add(product);
             CatalogueDb.SaveChanges();
             return product;
        }
         [HttpPut("{id}")]
        public Product Update([FromBody] Product product, long id) {
             product.ProductID = id;
             CatalogueDb.products.Update(product);
             CatalogueDb.SaveChanges();
             return product;
        }

        [HttpDelete("{id}")]
        public void Delete(long id) {
            Product product = CatalogueDb.products.FirstOrDefault(p=>p.ProductID == id);
            CatalogueDb.products.Remove(product);
            CatalogueDb.SaveChanges();
        }
    }
}