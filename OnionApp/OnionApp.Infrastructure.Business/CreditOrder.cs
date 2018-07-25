using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionApp.Domain.Core;
using OnionApp.Services.Interfaces;

namespace OnionApp.Infrastructure.Business
{
    class CreditOrder : IOrder
    {
        public void MakeOrder(Book book)
        {
            // код покупки с помощью кредитной карты
        }
    }
}
