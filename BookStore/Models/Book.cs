using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        // ID of Book
        public int Id { get; set; }
        
        // Title of Book

        public string Name { get; set; }

        // Author

        public string Author { get; set; }

        // Price

        public int Price { get; set; }

    }
}