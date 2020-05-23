using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddProducts.Models
{
    public class AddProductsItem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Task Required")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

    }
}
