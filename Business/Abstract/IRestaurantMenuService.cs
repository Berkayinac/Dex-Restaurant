using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRestaurantMenuService
    {
        IDataResult<List<RestaurantMenu>> GetAll();
        IDataResult<RestaurantMenu> GetById(int id);
        IResult Add(RestaurantMenu restaurantMenu);
        IResult Update(RestaurantMenu restaurantMenu);
        IResult Delete(RestaurantMenu restaurantMenu);
    }
}

