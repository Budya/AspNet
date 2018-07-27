using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UnitOfWorkApp.Models
{
    public class BookDbInitialiser : DropCreateDatabaseAlways<OrderContext>
    {
        protected override void Seed(OrderContext context)
        {
            var book = new Book {Id = 1, Name = "Kujo", Price = 15};

            context.Books.Add(book);
            context.SaveChanges();
        }
    }
}