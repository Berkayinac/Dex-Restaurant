using Business.Abstract;
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
    public class RestaurantMenuManager : IRestaurantMenuService
    {
        private IRestaurantMenuDal _restaurantMenuDal;
        public RestaurantMenuManager(IRestaurantMenuDal restaurantMenuDal)
        {
            _restaurantMenuDal = restaurantMenuDal;
        }

        public IResult Add(RestaurantMenu restaurantMenu)
        {
            _restaurantMenuDal.Add(restaurantMenu);
            return new SuccessResult();
        }

        public IResult Delete(RestaurantMenu restaurantMenu)
        {
            _restaurantMenuDal.Delete(restaurantMenu);
            return new SuccessResult();
        }

        public IDataResult<List<RestaurantMenu>> GetAll()
        {
            var result = _restaurantMenuDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<RestaurantMenu>>();
            }
            return new SuccessDataResult<List<RestaurantMenu>>(result);
        }

        public IDataResult<RestaurantMenu> GetById(int id)
        {
            var result = _restaurantMenuDal.Get(r=>r.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<RestaurantMenu>();
            }
            return new SuccessDataResult<RestaurantMenu>(result);
        }

        public IResult Update(RestaurantMenu restaurantMenu)
        {
            _restaurantMenuDal.Update(restaurantMenu);
            return new SuccessResult();
        }
    }
}
