using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Purchase
    {
        // ID of Purchase
        public int PurchaseId { get; set; }

        // Person Data
        public string Person { get; set; }

        // Adress of person
        public string Adress { get; set; }

        // Id book
        public int BookId { get; set; }

        // Date of purchase

        public DateTime Date { get; set; }
    }
}