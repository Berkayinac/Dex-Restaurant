using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminMenuService
    {
        IDataResult<List<AdminMenu>> GetAll();
        IDataResult<AdminMenu> GetById(int id);
        IResult Add(AdminMenu adminMenu);
        IResult Update(AdminMenu adminMenu);
        IResult Delete(AdminMenu adminMenu);
    }
}
