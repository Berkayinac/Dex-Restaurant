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
    public class AdminMenuManager : IAdminMenuService
    {

        IAdminMenuDal _adminMenuDal;

        public AdminMenuManager()
        {
            _adminMenuDal = new EfAdminMenuDal();
        }

        public IResult Add(AdminMenu adminMenu)
        {
            _adminMenuDal.Add(adminMenu);
            return new SuccessResult();
        }

        public IResult Delete(AdminMenu adminMenu)
        {
            _adminMenuDal.Delete(adminMenu);
            return new SuccessResult();
        }

        public IDataResult<List<AdminMenu>> GetAll()
        {
            var result = _adminMenuDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<AdminMenu>>();
            }
            return new SuccessDataResult<List<AdminMenu>>(result);
        }

        public IDataResult<AdminMenu> GetById(int id)
        {
            var result = _adminMenuDal.Get(a => a.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<AdminMenu>();
            }
            return new SuccessDataResult<AdminMenu>(result);
        }

        public IResult Update(AdminMenu adminMenu)
        {
            _adminMenuDal.Update(adminMenu);
            return new SuccessResult();
        }
    }
}
