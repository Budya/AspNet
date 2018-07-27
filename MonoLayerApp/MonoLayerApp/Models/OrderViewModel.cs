using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoLayerApp.Models
{
    public class OrderViewModel
    {
        public int PhoneId { get; set; } // id телефона 
        public string Address { get; set; } // адрес 
        public string PhoneNumber { get; set; } // номер телефона покупателя 

    }
}