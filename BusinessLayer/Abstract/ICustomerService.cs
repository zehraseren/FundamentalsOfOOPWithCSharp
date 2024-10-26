﻿using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICustomerService : IGenericService<Customer>
    {
        List<Customer> GetCustomersListWithJob();
    }
}