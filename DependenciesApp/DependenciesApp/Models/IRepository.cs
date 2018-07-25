using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependenciesApp.Models
{
    public interface IRepository
    {
        void Save(Book b);
        IEnumerable<Book> List();
        Book Get(int id);
    }
}
