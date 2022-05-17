using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCartDal : EfEntityRepositoryBase<Cart, DexContext>, ICartDal
    {
        public List<CartDto> GetAllCartDto(User user)
        {
            using (DexContext context = new DexContext())
            {
                var result = from product in context.Products
                             join cart in context.Carts
                             on product.Id equals cart.ProductId
                             where cart.UserId == user.Id
                             select new CartDto
                             {
                                 ProductName = product.Name,
                                 Quantity = cart.Quantity,
                                 UserName = user.FirstName + " " + user.LastName,
                                 ProductUnitPrice = product.UnitPrice,
                                 ProductId = product.Id,
                                 CartId = cart.Id,
                                 Photo = product.Photo
                             };
                return result.ToList();
            }
        }
    }
}
