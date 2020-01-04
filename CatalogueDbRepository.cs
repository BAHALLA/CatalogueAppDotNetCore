
using Microsoft.EntityFrameworkCore;
using CatalogueApp.Models;

namespace CatalogueApp {

    public class CatalogueDbRepository: DbContext {

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public CatalogueDbRepository(DbContextOptions options) : base(options){}
    }
}