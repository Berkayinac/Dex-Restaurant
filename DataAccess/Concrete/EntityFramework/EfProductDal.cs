using Core.DataAccess.EntityFramework;
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
    public class EfProductDal : EfEntityRepositoryBase<Product,DexContext>, IProductDal
    {
        public List<ProductDto> GetProductDtos()
        {
            using (DexContext context = new DexContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             select new ProductDto
                             {
                                 Id = p.Id,
                                 CategoryName = c.Name,
                                 Name = p.Name,
                                 UnitPrice = p.UnitPrice,
                                 UnitsInStock = p.UnitsInStock,
                                 Photo = p.Photo
                             };
                return result.ToList();
            }
        }
    }
}
