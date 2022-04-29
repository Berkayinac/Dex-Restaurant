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
                var result = from cart in context.Carts
                             join product in context.Products
                             on cart.ProductId equals product.Id
                             where cart.UserId == user.Id
                             select new CartDto
                             {
                                 ProductName = product.Name,
                                 Quantity = 1,
                                 UserName = user.FirstName + " " + user.LastName
                             };
                return result.ToList();
            }
        }
    }
}
