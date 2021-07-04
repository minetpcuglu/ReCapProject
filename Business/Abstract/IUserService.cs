using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();

        IDataResult<User> GetById(int userId);
     

        IResult add(User user);
        //void delete(Brand brand);
        IResult delete(User user);
        IResult update(User user);
    }
}
