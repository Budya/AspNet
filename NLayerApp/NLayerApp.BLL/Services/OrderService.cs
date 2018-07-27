using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NLayerApp.BLL.BusinessModels;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.BLL.Interfaces;
using NLayerApp.DAL.Entitties;
using NLayerApp.DAL.Interfaces;

namespace NLayerApp.BLL.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOrder(OrderDTO orderDto)
        {
            Phone phone = Database.Phones.Get(orderDto.PhoneId);

            //валидация
            if(phone == null)
                throw new ValidationException("Телефон не найден","");
            // применяем скидку
            decimal sum = new Discount(0.1m).GetDiscountedPrice(phone.Price);

            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                PhoneId = phone.Id,
                Sum = sum,
                PhoneNumber = orderDto.PhoneNumber
            };

            Database.Orders.Create(order);
            Database.Save();
        }

        public PhoneDTO GetPhone(int? id)
        {
            if(id==null)
                throw new ValidationException("Не установлен" +
                                              "id телефона","");
            var phone = Database.Phones.Get(id.Value);
            if(phone == null)
                throw new ValidationException("Телефон не найден","");

            // применяем автомаппер
            Mapper.CreateMap<Phone, PhoneDTO>();
            return Mapper.Map<Phone, PhoneDTO>(phone);
        }

        public IEnumerable<PhoneDTO> GetPhones()
        {
            // применяем автомаппер для проекции одной коллекции
            // на другую
            Mapper.CreateMap<Phone, PhoneDTO>();
            return Mapper.Map<IEnumerable<Phone>, List<PhoneDTO>>(Database.Phones.GetAll());

        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
