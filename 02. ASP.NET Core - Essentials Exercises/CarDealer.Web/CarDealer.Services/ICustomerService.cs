namespace CarDealer.Services
{
    using Models;
    using Models.Customers;
    using System;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> Ordered(OrderDirection order);

        CustomerTotalSalesModel TotalSalesById(int id);

        void Create(string name, DateTime birthday, bool isYoungDriver);

        void Edit(int id, string name, DateTime birthDay, bool isYoungDriver);

        CustomerModel ById(int id);

        bool Exists(int id);
    }
}