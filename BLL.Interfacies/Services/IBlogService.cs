using System.Collections.Generic;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.FullModel;

namespace BLL.Interfacies.Services
{
    public interface IBlogService
    {
        FullBlogEntity GetBlogById(int id);
        FullBlogEntity GetBlogByName(string name);
        void CreateBlog(FullBlogEntity entity);
        void DeleteBlog(FullBlogEntity entity);
        void UpdateBlog(FullBlogEntity entity);
        IEnumerable<BlogEntity> GetAllSimpleBlogs();
        BlogEntity GetSimpleBlogById(int id);
        IEnumerable<BlogEntity> GetAllByUser(int userId);
    }
}
