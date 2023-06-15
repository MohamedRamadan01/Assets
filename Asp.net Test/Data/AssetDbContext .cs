using Assets.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assets.Data
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext() : base("Data Source=DESKTOP-AFMALD3\\SQLEXPRESS;Initial Catalog=AssetsDb;Integrated Security=True;")
        {
        }

        public DbSet<Asset> Assets { get; set; }
    }
}