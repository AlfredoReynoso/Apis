using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Apis.Models
{
    public class FerreteriaContext : DbContext
    {
        public DbSet<CatProductos> CatProductos { get; set; }

    }
}