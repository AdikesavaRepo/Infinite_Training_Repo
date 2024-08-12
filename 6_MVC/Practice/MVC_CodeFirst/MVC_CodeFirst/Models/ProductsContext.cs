using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data;


namespace MVC_CodeFirst.Models
{
    public class ProductsContext : DbContext
    {
        public ProductsContext() : base("connectstr")
        { }

        public DbSet<Products> Product { get; set; }
        public DbSet<Sales> Sale { get; set; }
    }
}