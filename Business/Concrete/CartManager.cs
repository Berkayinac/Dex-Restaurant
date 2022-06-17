using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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
        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public IResult Add(Cart cart)
        {
            var rules = BusinessRules.Run(CheckDataIsNull(cart));

            if (!rules.Success)
            {
                return new ErrorResult();
            }

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

        // Technical Debt
        public IResult CheckCart(Cart cart)
        {
            var getItem = _cartDal.Get(c => c.ProductId == cart.ProductId && c.UserId == cart.UserId);

            var result = Add(getItem);

            if (result.Success)
            {
                return new SuccessResult();
            }

            return QuantityUpdate(cart, getItem);
        }

        private IResult QuantityUpdate(Cart cart, Cart getItem)
        {
            getItem.Quantity += cart.Quantity;
            Update(getItem);
            return new SuccessResult();
        }

        public IResult CartDelete(Cart cart)
        {
            var getItem = _cartDal.Get(c => c.ProductId == cart.ProductId && c.UserId == cart.UserId);
            if (getItem == null)
            {
                return new ErrorResult();
            }
            if (getItem.Quantity >1)
            {
                getItem.Quantity -= cart.Quantity;
                Update(getItem);
                return new SuccessResult();
            }
            else
            {
                Delete(getItem);
                return new SuccessResult();
            }
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


        private IResult CheckProcess(IResult result)
        {
            if (result.Success)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IResult CheckDataIsNull(Cart cart)
        {
            if (cart == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
