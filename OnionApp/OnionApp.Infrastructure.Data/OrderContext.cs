using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionApp.Domain.Core;
using OnionApp.Domain.Interfaces;

namespace OnionApp.Infrastructure.Data
{
    public class OrderContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
