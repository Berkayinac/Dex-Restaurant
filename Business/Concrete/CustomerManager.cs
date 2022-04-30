using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        public CustomerManager()
        {
            _customerDal = new EfCustomerDal();
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Customer>>();
            }
            return new SuccessDataResult<List<Customer>>(result, Messages.CustomersListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            var result = _customerDal.Get(c => c.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Customer>();
            }
            return new SuccessDataResult<Customer>(result, Messages.CustomerGeted);
        }

        public IDataResult<Customer> GetByUserId(int userId)
        {
            var result = _customerDal.Get(c => c.UserId == userId);
            if (result == null)
            {
                return new ErrorDataResult<Customer>();
            }
            return new SuccessDataResult<Customer>(result, Messages.CustomerGeted);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
