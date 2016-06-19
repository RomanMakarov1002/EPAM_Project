using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interfacies.DTO;
using ORM;

namespace DAL.DALMappers
{
    public static class DalMapper
    {

        #region UsersDalMapper

        public static User ToOrmUser(this DalUser user)
        {
            return new User()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                NickName = user.NickName,
                Password = user.Password,
                Email = user.Email,
                JoinTime = user.JoinTime,
                AvatarPath = user.AvatarPath
            };
        }

        public static DalUser ToDalUser(this User user)
        {
            return new DalUser()
            {
                Id = user.Id,
                Name = user.Name,
                Surname =user.Surname,
                NickName = user.NickName,
                Password = user.Password,
                Email = user.Email,
                JoinTime = user.JoinTime,
                AvatarPath = user.AvatarPath
            };
        }

        #endregion

        #region UserRoleDalMapper

        public static DalUserRole ToDalUserRole(this UserRole role)
        {
            return new DalUserRole
            {
                UserId = role.UserId,
                RoleId = role.RoleId
            };
        }

        public static UserRole ToOrmUserRole(this DalUserRole role)
        {
            return new UserRole
            {
                UserId = role.UserId,
                RoleId = role.RoleId
            };
        }

        #endregion

        #region RolesDalMapper

        public static Role ToOrmRole(this DalRole role)
        {
            return new Role
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
            };
        }

        public static DalRole ToDalRole(this Role role)
        {
            return new DalRole
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
            };
        }

        #endregion

        #region ArticlesDalMapper

        public static DalArticle ToDalArticle(this Article article)
        {
            return new DalArticle
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

        public static Article ToOrmArticle(this DalArticle article)
        {
            return new Article
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

        #endregion

        #region TagsDalMapper

        public static DalTag ToDalTag(this Tag tag)
        {
            return new DalTag
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        public static Tag ToOrmTag(this DalTag tag)
        {
            return new Tag
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        #endregion

        #region ArticleTagDalMapper

        public static DalArticleTag ToDalArticleTag(this ArticleTag e)
        {
            return new DalArticleTag
            {
                ArticleId = e.ArticleId,
                TagId = e.TagId
            };
        }

        public static ArticleTag ToOrmArticleTag(this DalArticleTag e)
        {
            return new ArticleTag
            {
                ArticleId = e.ArticleId,
                TagId = e.TagId
            };
        }

        #endregion

        #region CommentsDalMapper

        public static Comment ToOrmComment(this DalComment e)
        {
            return new Comment()
            {
                Id = e.Id,
                DateTime = e.DateTime,
                Text = e.Text,
                UserId = e.UserId,
                ArticleId = e.ArticleId
            };
        }

        public static DalComment ToDalComment(this Comment e)
        {
            return new DalComment()
            {
                Id = e.Id,
                DateTime = e.DateTime,
                Text = e.Text,
                UserId = e.UserId,
                ArticleId = e.ArticleId
            };
        }

        #endregion

        #region BlogsDalMapper

        public static DalBlog ToDalBlog(this Blog blog)
        {
            return new DalBlog()
            {
                Id = blog.Id,
                Name = blog.Name,
                UserId = blog.UserId
            };
        }

        public static Blog ToOrmBlog(this DalBlog blog)
        {
            return new Blog()
            {
                Id = blog.Id,
                Name = blog.Name,
                UserId = blog.UserId
            };
        }

        #endregion

    }
}
