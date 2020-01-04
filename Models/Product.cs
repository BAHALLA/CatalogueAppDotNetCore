using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CatalogueApp.Models;

namespace CatalogueApp.Models {

    [Table("Products")]
    public class Product {
        [Key]
        public long ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public long CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
    }
}