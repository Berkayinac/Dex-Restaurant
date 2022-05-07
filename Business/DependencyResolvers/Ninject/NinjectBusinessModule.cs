using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Ninject
{
    public class NinjectBusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Bind<ICustomerService>().To<CustomerManager>().InSingletonScope();
            Bind<ICustomerDal>().To<EfCustomerDal>().InSingletonScope();

            Bind<IOrderService>().To<OrderManager>().InSingletonScope();
            Bind<IOrderDal>().To<EfOrderDal>().InSingletonScope();

            Bind<ICartService>().To<CartManager>().InSingletonScope();
            Bind<ICartDal>().To<EfCartDal>().InSingletonScope();

            Bind<ISecurityQuestionService>().To<SecurityQuestionManager>().InSingletonScope();
            Bind<ISecurityQuestionDal>().To<EfSecurityQuestionDal>().InSingletonScope();

            Bind<IAuthorityService>().To<AuthorityManager>().InSingletonScope();
            Bind<IAuthorityDal>().To<EfAuthorityDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind<IUserAuthorityService>().To<UserAuthorityManager>().InSingletonScope();
            Bind<IUserAuthorityDal>().To<EfUserAuthorityDal>().InSingletonScope();

            Bind<IAdminMenuService>().To<AdminMenuManager>().InSingletonScope();
            Bind<IAdminMenuDal>().To<EfAdminMenuDal>().InSingletonScope();

            Bind<IRestaurantMenuService>().To<RestaurantMenuManager>().InSingletonScope();
            Bind<IRestaurantMenuDal>().To<EfRestaurantMenuDal>().InSingletonScope();

            Bind<IAuthService>().To<AuthManager>().InSingletonScope();
        }
    }
}
