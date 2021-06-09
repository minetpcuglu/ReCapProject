using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();

        IDataResult<Customer> GetById(int customerId); 
        IDataResult<Customer> GetCustomerByCustomerId(int customerid);

        IResult add(Customer customer);
        //void delete(Brand brand);
        IResult delete(Customer customer);
        IResult update(Customer customer);
    }
}
