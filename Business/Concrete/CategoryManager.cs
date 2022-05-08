using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.FluentValidation;
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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            ValidationTool.Validate(new CategoryValidator(), category);

            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Category>>();
            }
            return new SuccessDataResult<List<Category>>(result, Messages.CategoriesListed);
        }

        public IDataResult<Category> GetById(int id)
        {
            var result = _categoryDal.Get(c=>c.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Category>();
            }
            return new SuccessDataResult<Category>(result, Messages.CategoryGeted);
        }

        public IResult Update(Category category)
        {
            ValidationTool.Validate(new CategoryValidator(), category);

            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
