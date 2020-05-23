using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AddProducts.Models;

namespace AddProducts.Data
{
    public class AddProductsContext : DbContext
    {
        public AddProductsContext(DbContextOptions<AddProductsContext> options) : base(options)
        {

        }
        public DbSet<AddProductsItem> AddProductsItem{ get; set; }
    }
}

