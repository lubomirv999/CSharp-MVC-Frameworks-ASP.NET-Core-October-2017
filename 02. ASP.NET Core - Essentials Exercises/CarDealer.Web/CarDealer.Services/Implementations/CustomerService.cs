namespace CarDealer.Services.Implementations
{
    using Data;
    using Data.Models;
    using Models;
    using Models.Customers;
    using Models.Sales;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, DateTime birthday, bool isYoungDriver)
        {
            var customer = new Customer
            {
                Name = name,
                BirthDay = birthday,
                IsYoungDriver = isYoungDriver
            };

            this.db.Add(customer);
            this.db.SaveChanges();
        }
        
        public void Edit(int id, string name, DateTime birthDay, bool isYoungDriver)
        {
            var existingCustomer = this.db.Customers.Find(id);

            if (existingCustomer == null)
            {
                return;
            }

            existingCustomer.Name = name;
            existingCustomer.BirthDay = birthDay;
            existingCustomer.IsYoungDriver = isYoungDriver;

            this.db.SaveChanges();
        }

        public IEnumerable<CustomerModel> Ordered(OrderDirection order)
        {
            var customersQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderDirection.Ascending:
                    customersQuery = customersQuery
                        .OrderBy(c => c.BirthDay)
                        .ThenBy(c => c.Name);

                    break;
                case OrderDirection.Descending:
                    customersQuery = customersQuery
                        .OrderByDescending(c => c.BirthDay)
                        .ThenBy(c => c.Name);

                    break;
                default:
                    throw new InvalidOperationException($"Invalid order direction: {order}.");
            }

            return customersQuery
                .Select(c => new CustomerModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDay = c.BirthDay,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();
        }

        public CustomerModel ById(int id)
            => this.db
                .Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDay = c.BirthDay,
                    IsYoungDriver = c.IsYoungDriver
                })
                .FirstOrDefault();
        
        public CustomerTotalSalesModel TotalSalesById(int id)
            => this.db
                .Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerTotalSalesModel
                {
                    Name = c.Name,
                    IsYoungDriver = c.IsYoungDriver,
                    BoughtCars = c.Sales.Select(s => new SaleModel
                    {
                        Price = s.Car.Parts.Sum(p => p.Part.Price),
                        Discount = s.Discount
                    })
                })
                .FirstOrDefault();

        public bool Exists(int id)
            => this.db.Customers.Any(c => c.Id == id);
    }
}
