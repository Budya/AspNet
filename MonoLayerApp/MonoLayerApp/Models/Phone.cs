using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoLayerApp.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}