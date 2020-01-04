using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections;
using CatalogueApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CatalogueApp.Controllers {

    [Route("/api/categories")]
    public class CategoryRestController: Controller {
        
        private CatalogueDbRepository CatalogueDb { get; set; }

        public CategoryRestController(CatalogueDbRepository catalogueContext) {
            this.CatalogueDb = catalogueContext;

        }

        [HttpGet]
        public IEnumerable<Category> FindAll() {
            return CatalogueDb.categories;
        }
        [HttpGet("{id}")]
        public Category FindOne(long id) {
            return CatalogueDb.categories.FirstOrDefault(c=>c.CategoryId ==id);
        }
         [HttpGet("{id}/products")]
        public IEnumerable<Product> FindProducts(long id) {
            Category category = CatalogueDb.categories.Include( c => c.products).FirstOrDefault(c=>c.CategoryId ==id);
            return category.products;
        }

         [HttpPost]
        public Category Save([FromBody] Category category) {
             CatalogueDb.categories.Add(category);
             CatalogueDb.SaveChanges();
             return category;
        }
         [HttpPut("{id}")]
        public Category Update([FromBody] Category category, long id) {
             category.CategoryId = id;
             CatalogueDb.categories.Update(category);
             CatalogueDb.SaveChanges();
             return category;
        }

        [HttpDelete("{id}")]
        public void Delete(long id) {
            Category category = CatalogueDb.categories.FirstOrDefault(c=>c.CategoryId ==id);
            CatalogueDb.categories.Remove(category);
            CatalogueDb.SaveChanges();
        }

    }
}