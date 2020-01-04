using CatalogueApp.Models;
namespace CatalogueApp.Services {

    public class DbInit {
        public static void DataInit(CatalogueDbRepository catalogueDb){
            catalogueDb.categories.Add(new Category(){Name = "Computers"});
            catalogueDb.categories.Add(new Category(){Name = "Phones"});
            catalogueDb.categories.Add(new Category(){Name = "Watches"});
            catalogueDb.products.Add(new Product() {Name= "DELL XPS", Price= 200800.50, CategoryID= 1});
            catalogueDb.products.Add(new Product() {Name= "HP 2019", Price= 100800.50, CategoryID= 1});
            catalogueDb.products.Add(new Product() {Name= "ThinkPade 7", Price= 278800.88, CategoryID= 1});
            catalogueDb.products.Add(new Product() {Name= "IPhone 8", Price= 600.96, CategoryID= 2});
            catalogueDb.products.Add(new Product() {Name= "Samsung Note 9", Price= 1900.50, CategoryID= 2});
            catalogueDb.SaveChanges();
        }
    }
}