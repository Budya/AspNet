using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionApp.Domain.Core;
using OnionApp.Services.Interfaces;

namespace OnionApp.Infrastructure.Business
{
    public class CachOrder : IOrder
    {
        public void MakeOrder(Book book)
        {
            // код покупки книги при оплате наличностью
        }
    }
}
