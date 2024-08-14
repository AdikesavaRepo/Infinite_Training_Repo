using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;

namespace CodeFirst_CC.Models
{
    public class ContextClass : DbContext
    {
        public ContextClass(): base("connectstr")
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}