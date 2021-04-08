using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValitadion;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class UserManager:IUserService
   {
       private IUserDal _userDal;

       public UserManager(IUserDal userDal)
       {
           _userDal = userDal;
       }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run(CheckIfEMailAdressExist(user.EMail));
            if (result!=null)
            {
                return result;
            }
            _userDal.Add(user);
            return new SuccessResult(UserMessages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(UserMessages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), UserMessages.UserListed);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            IResult result = BusinessRules.Run(CheckIfEMailAdressExist(user.EMail));
            if (result != null)
            {
                return result;
            }
            _userDal.Update(user);
            return new SuccessResult(UserMessages.UserUpdated);
        }

        private IResult CheckIfEMailAdressExist(string eMail)
        {
            var result = _userDal.GetAll(u => u.EMail == eMail).Any();

            if (result)
            {
                new ErrorResult(UserMessages.EMailAdressAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
