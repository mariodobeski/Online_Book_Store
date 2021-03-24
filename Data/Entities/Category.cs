using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }

        public List<Subcategory> Subcategory { get; set; }
    }
}