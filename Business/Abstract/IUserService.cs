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
        IDataResult<User> GetByMail(string userMail);
     

        IResult add(User user);
        //void delete(Brand brand);
        IResult delete(User user);
        IResult update(User user);

        List<OperationClaims> GetClaims(User user); //jwt için claimleri çek ...
        void Add(User user); // jwt 
        User GetByEMail(string email); //emaile göre kullanıcı getir kullanıcı ekle
    }
}
