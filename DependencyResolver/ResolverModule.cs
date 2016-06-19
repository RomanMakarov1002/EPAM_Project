using System.Data.Entity;
using BLL.Interfacies.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interfacies.Repository;
using Ninject;
using Ninject.Web.Common;
using ORM;

namespace DependencyResolver
{
    public static class ResolverConfig 
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<EntityModel>().To<EntityModel>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<EntityModel>().To<EntityModel>().InSingletonScope();
            }

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();

            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<ICommentRepository>().To<CommentRepository>();

            kernel.Bind<IUserRoleRepository>().To<UserRoleRepository>();

            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IRoleService>().To<RoleService>();

            kernel.Bind<IArticleRepository>().To<ArticleRepository>();
            kernel.Bind<IArticleService>().To<ArticleService>();

            kernel.Bind<ITagRepository>().To<TagRepository>();
            kernel.Bind<ITagService>().To<TagService>();

            kernel.Bind<IArticleTagRepository>().To<ArticleTagRepository>();

            kernel.Bind<IBlogRepository>().To<BlogRepository>();
            kernel.Bind<IBlogService>().To<BlogService>();
        }
    }
}