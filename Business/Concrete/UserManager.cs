using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public void Add(User user)  //jwt
        {
            _userDal.Add(user);
        }

        public IResult delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        //[ValidationAspect(typeof(UserValidator))]
        public IDataResult<List<User>> GetAll()
        {
            //İş kodları yazılır
            //if (DateTime.Now.Hour == 4 )
            //{
            //    return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public User GetByEMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(x =>x.Id== userId), Messages.FilterId);
        }

        public IDataResult<User> GetByMail(string userMail)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.Email == userMail),Messages.ListMail);
        }

        public List<OperationClaims> GetClaims(User user)
        {
           return _userDal.GetClaims(user);
        }

        public IResult update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
