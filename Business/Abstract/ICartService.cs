using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartService 
    {
        IDataResult<List<Cart>> GetAll();
        IDataResult<List<CartDto>> GetAllDtos(User user);
        IDataResult<Cart> GetById(int id);
        IResult Add(Cart cart);
        IResult Update(Cart cart);
        IResult Delete(Cart cart);
        IResult CheckCart(Cart cart);
        //IResult CartDelete(Cart cart);
        IDataResult<Cart> GetIfExistCartItem(Cart cart);
    }
}
