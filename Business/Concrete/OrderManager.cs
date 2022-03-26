using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Concrete.EntityFramework;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager()
        {
            _orderDal = new EfOrderDal();
        }

        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult(Messages.OrderAdded);
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.OrderDeleted);
        }

        public IDataResult<List<Order>> GetAll()
        {
            var result = _orderDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Order>>();
            }
            return new SuccessDataResult<List<Order>>(result, Messages.OrdersListed);
        }

        public IDataResult<Order> GetById(int id)
        {
            var result = _orderDal.Get(o => o.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Order>();
            }
            return new SuccessDataResult<Order>(result, Messages.OrderGeted);
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
