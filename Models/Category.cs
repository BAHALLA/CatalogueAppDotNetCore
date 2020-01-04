using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CatalogueApp.Models {

    [Table("Categoris")]
    public class Category {
        [Key]
        public long CategoryId { get; set; }

        [ Required, StringLength(35)]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Product> products { get; set; }
    }
}