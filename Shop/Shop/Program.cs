using System;
using Shop.Entities;
using Shop.Entities.Enums;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order
            {
                Id = 1000,
                Moment = DateTime.Now,
                Status = OrderStatus.PendingPayment
            };

            Console.WriteLine(order);
        }
    }
}
