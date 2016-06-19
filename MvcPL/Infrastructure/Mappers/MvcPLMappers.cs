using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.FullModel;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcMappers
    {

        #region UsersMapper
        public static SimpleUserViewModel ToMvcUser(this UserEntity userEntity)
        {
            return new SimpleUserViewModel()
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Surname = userEntity.Surname,
                NickName = userEntity.NickName,
                Password = userEntity.Password,
                Email = userEntity.Email,
                JoinTime = userEntity.JoinTime,
                AvatarPath = userEntity.AvatarPath
            };
        }

        public static UserEntity ToBllUser(this SimpleUserViewModel userViewModel)
        {
            return new UserEntity()
            {
                Id = userViewModel.Id,
                Name = userViewModel.Name,
                Surname = userViewModel.Surname,
                NickName = userViewModel.NickName,
                Password = userViewModel.Password,
                Email = userViewModel.Email,
                JoinTime = userViewModel.JoinTime,
                AvatarPath = userViewModel.AvatarPath
            };
        }

        public static FullUserViewModel ToFullMvcUser(this FullUserEntity fullEntity)
        {
            return new FullUserViewModel
            {
                Id = fullEntity.Id,
                Name = fullEntity.Name,
                Surname = fullEntity.Surname,
                NickName = fullEntity.NickName,
                Password = fullEntity.Password,
                Email = fullEntity.Email,
                JoinTime = fullEntity.JoinTime,
                AvatarPath = fullEntity.AvatarPath,
                Roles = fullEntity.Roles.Select(role => role.ToMvcSimpleRole())
            };
        }

        public static FullUserEntity ToFullBllUser(this FullUserViewModel fullModel)
        {
            return new FullUserEntity
            {
                Id = fullModel.Id,
                Name = fullModel.Name,
                Surname = fullModel.Surname,
                NickName = fullModel.NickName,
                Password = fullModel.Password,
                Email = fullModel.Email,
                JoinTime = fullModel.JoinTime,
                AvatarPath = fullModel.AvatarPath,
                Roles = fullModel.Roles.Select(role => role.ToBllSimpleRole())
            };
        }
        #endregion

        #region RolesMapper
        public static SimpleRoleViewModel ToMvcSimpleRole(this RoleEntity role)
        {
            return new SimpleRoleViewModel
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static RoleEntity ToBllSimpleRole(this SimpleRoleViewModel role)
        {
            return new RoleEntity
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        #endregion

        #region CommentsMapper

        public static CommentEntity ToBllComment(this CommentViewModel comment)
        {
            return new CommentEntity()
            {
                Id = comment.Id,
                DateTime = comment.DateTime,
                Text = comment.Text,
                UserId = comment.UserId,
                ArticleId = comment.ArticleId
                
            };
        }

        public static CommentViewModel ToMvcComment(this CommentEntity comment)
        {
            return new CommentViewModel()
            {
                Id = comment.Id,
                DateTime = comment.DateTime,
                Text = comment.Text,
                UserId = comment.UserId,
                ArticleId = comment.ArticleId
            };
        }

        public static FullCommentEntity ToBllFullComment(this FullCommentViewModel comment)
        {
            return new FullCommentEntity()
            {
                Id = comment.Id,
                DateTime = comment.DateTime,
                Text = comment.Text,
                User = comment.User?.ToBllUser(),
                ArticleId = comment.ArticleId
            };
        }

        public static FullCommentViewModel ToMvcFullComment(this FullCommentEntity comment)
        {
            return new FullCommentViewModel()
            {
                Id = comment.Id,
                DateTime = comment.DateTime,
                Text = comment.Text,
                User = comment.User?.ToMvcUser(),
                ArticleId = comment.ArticleId
            };
        }

        #endregion

        #region ArticlesMapper
        public static ArticleEntity ToBllSimpleArticle(this SimpleArticleViewModel article)
        {
            return new ArticleEntity()
            {
                Id = article.Id,
                Title = article.Title,
                CreationTime = article.CreationTime,
                Text = article.Text,
                TitleImage = article.TitleImage,
                UserId = article.UserId,
                BlogId = article.BlogId
            };
        }

        public static SimpleArticleViewModel ToMvcSimpleArticle(this ArticleEntity article)
        {
            return new SimpleArticleViewModel()
            {
                Id = article.Id,
                Title = article.Title,
                CreationTime = article.CreationTime,
                Text = article.Text,
                TitleImage = article.TitleImage,
                UserId = article.UserId,
                BlogId = article.BlogId
            };
        }

        public static FullArticleEntity ToBllFullArticle(this FullArticleViewModel article)
        {
            return new FullArticleEntity()
            {
                Id = article.Id,
                Title = article.Title,
                CreationTime = article.CreationTime,
                Text = article.Text,
                User = article.User.ToBllUser(),
                TitleImage = article.TitleImage,
                Blog = article.Blog?.ToBllSimpleBlog(),
                Tags = article.Tags?.Select(x => x.ToBllSimpleTag())
            };
        }

        public static FullArticleViewModel ToMvcFullArticle(this FullArticleEntity article)
        {
            return new FullArticleViewModel()
            {
                Id = article.Id,
                Title = article.Title,
                CreationTime = article.CreationTime,
                Text = article.Text,
                User = article.User.ToMvcUser(),
                TitleImage = article.TitleImage,
                Blog = article.Blog?.ToMvcSimpleBlog(),
                Tags = article.Tags.Select( x => x.ToMvcSimpleTag()),
                Comments = article.Comments.Select(x => x.ToMvcFullComment())
            };
        }

        #endregion

        #region TagsMapper

        public static TagEntity ToBllSimpleTag(this SimpleTagViewModel tag)
        {
            return new TagEntity()
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        public static SimpleTagViewModel ToMvcSimpleTag(this TagEntity tag)
        {
            return new SimpleTagViewModel()
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        public static FullTagEntity ToBllFullTag(this FullTagViewModel fullTag)
        {
            return new FullTagEntity()
            {
                Id = fullTag.Id,
                Name = fullTag.Name,
                Articles = fullTag.Articles.Select( x => x.ToBllSimpleArticle())
            };
        }

        public static FullTagViewModel ToMvcFullTag(this FullTagEntity fullTag)
        {
            return new FullTagViewModel()
            {
                Id = fullTag.Id,
                Name = fullTag.Name,
                Articles = fullTag.Articles.Select( x => x.ToMvcSimpleArticle())
            };
        }

        #endregion

        #region BlogsMapper
        public static FullBlogViewModel ToMvcFullBlog(this FullBlogEntity fullBlog)
        {
            return new FullBlogViewModel()
            {
                Id = fullBlog.Id,
                Name = fullBlog.Name,
                User = fullBlog.User?.ToMvcUser()
            };
        }

        public static FullBlogEntity ToBllFullBlog(this FullBlogViewModel fullBlog)
        {
            return new FullBlogEntity()
            {
                Id = fullBlog.Id,
                Name = fullBlog.Name,
                User = fullBlog.User?.ToBllUser(),
                Articles = fullBlog.Articles?.Select(x => x.ToBllFullArticle())
            };
        }

        public static SimpleBlogViewModel ToMvcSimpleBlog(this BlogEntity blog)
        {
            return new SimpleBlogViewModel()
            {
                Id = blog.Id,
                Name = blog.Name,
                UserId = blog.UserId
            };
        }

        public static BlogEntity ToBllSimpleBlog(this SimpleBlogViewModel blog)
        {
            return new BlogEntity()
            {
                Id = blog.Id,
                Name = blog.Name,
                UserId = blog.UserId
            };
        }
        #endregion
    }
}