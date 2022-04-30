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
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<ProductDto>> GetAllByDto();
        IDataResult<Product> GetById(int id);
        IDataResult<Product> GetByName(string name);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
    }
}
