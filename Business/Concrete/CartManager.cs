using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartDal _cartDal;
        public CartManager()
        {
            _cartDal = new EfCartDal();
        }

        public IResult Add(Cart cart)
        {
            _cartDal.Add(cart);
            return new SuccessResult(Messages.CartAdded);
        }

        public IResult Delete(Cart cart)
        {
            _cartDal.Delete(cart);
            return new SuccessResult(Messages.CartDeleted);
        }

        public IDataResult<List<Cart>> GetAll()
        {
            var result = _cartDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Cart>>();
            }
            return new SuccessDataResult<List<Cart>>(result, Messages.CartListed);
        }

        public IDataResult<List<CartDto>> GetAllDtos(User user)
        {
            var result = _cartDal.GetAllCartDto(user);
            if (result == null)
            {
                return new ErrorDataResult<List<CartDto>>();
            }
            return new SuccessDataResult<List<CartDto>>(result, Messages.CartListed);
        }

        public IDataResult<Cart> GetById(int id)
        {
            var result = _cartDal.Get(c => c.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Cart>();
            }
            return new SuccessDataResult<Cart>(result, Messages.CartGeted);
        }

        public IResult Update(Cart cart)
        {
            _cartDal.Update(cart);
            return new SuccessResult(Messages.CartUpdated);
        }
    }
}
