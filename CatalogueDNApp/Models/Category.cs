using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CatalogueDNApp.Models{
    [Table("CATEGORIES")]
    public class Category{
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection <Product> Products { get; set; }
    }
}