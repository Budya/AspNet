﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonoLayerApp.Models
{
    public class MobileContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }
    }

    public class StoreDbInitializer : DropCreateDatabaseAlways<MobileContext>
    {
        protected override void Seed(MobileContext db)
        {
            db.Phones.Add(new Phone {Name = "Nokia Lumia 630", Company = "Nokia", Price = 220});
            db.Phones.Add(new Phone {Name = "iPhone 6", Company = "Apple", Price = 320});
            db.Phones.Add(new Phone {Name = "LG G4", Company = "lG", Price = 260});
            db.Phones.Add(new Phone {Name = "Samsung Galaxy S 6", Company = "Samsung", Price = 300});

            db.SaveChanges();
        }
    }
}