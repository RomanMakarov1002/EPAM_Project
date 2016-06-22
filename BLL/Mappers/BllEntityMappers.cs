using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.FullModel;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {

        #region UsersBllMapper

        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            return new DalUser()
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

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            return new UserEntity()
            {
                Id = dalUser.Id,
                Name = dalUser.Name,
                Surname = dalUser.Surname,
                NickName = dalUser.NickName,
                Password = dalUser.Password,
                Email = dalUser.Email,
                JoinTime = dalUser.JoinTime,
                AvatarPath = dalUser.AvatarPath
            };
        }

        public static DalUser ToDalUser(this FullUserEntity fullUser)
        {
            return new DalUser()
            {
                Id = fullUser.Id,
                Name = fullUser.Name,
                Surname = fullUser.Surname,
                NickName = fullUser.NickName,
                Password = fullUser.Password,
                Email = fullUser.Email,
                JoinTime = fullUser.JoinTime,
                AvatarPath = fullUser.AvatarPath
            };
        }
        #endregion

        #region CommentsBllMapper

        public static CommentEntity ToCommentEntity(this DalComment comment)
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

        public static FullCommentEntity ToFullCommentEntity(this DalComment comment)
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
        public static DalComment ToDalComment(this CommentEntity comment)
        {
            return new DalComment()
            {
                Id = comment.Id,
                DateTime = comment.DateTime,
                Text = comment.Text,
                UserId = comment.UserId,
                ArticleId = comment.ArticleId
            };
        }

        public static DalComment ToDalComment(this FullCommentEntity fullComment)
        {
            DalComment comment = new DalComment()
            {
                Id = fullComment.Id,
                DateTime = fullComment.DateTime,
                Text = fullComment.Text,
                ArticleId = fullComment.ArticleId
            };
            if (fullComment.User != null)
                comment.UserId = fullComment.User.Id;
            return comment;
        }

        #endregion

        #region UserRoleMapper
        public static UserRoleEntity ToBllUserRole(this DalUserRole userRole)
        {
            return new UserRoleEntity
            {
                UserId = userRole.UserId,
                RoleId = userRole.RoleId
            };
        }

        public static DalUserRole ToDalUserRole(this UserRoleEntity userRole)
        {
            return new DalUserRole
            {
                UserId = userRole.UserId,
                RoleId = userRole.RoleId
            };
        }

        #endregion

        #region RolesBllMapper

        public static RoleEntity ToBllRole(this DalRole role)
        {
            return new RoleEntity
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                
            };
        }

        public static DalRole ToDalRole(this RoleEntity role)
        {
            return new DalRole
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        #endregion

        #region ArticlesBllMapper

        public static DalArticle ToDalArticle(this ArticleEntity article)
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

        public static ArticleEntity ToBllArticle(this DalArticle article)
        {
            return new ArticleEntity
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

        public static DalArticle ToDalArticle(this FullArticleEntity article)
        {
            return new DalArticle()
            {
                Id = article.Id,
                Title = article.Title,
                CreationTime = article.CreationTime,
                Text = article.Text,
                TitleImage = article.TitleImage,
                UserId = article.User.Id,
                BlogId = article.Blog.Id
            };
        }
        #endregion

        #region ArticleTagMapper

        public static ArticleTagEntity ToBllArticleTag(this DalArticleTag articleTag)
        {
            return new ArticleTagEntity
            {
                ArticleId = articleTag.ArticleId,
                TagId = articleTag.TagId
            };
        }

        public static DalArticleTag ToDalArticleTag(this ArticleTagEntity articleTag)
        {
            return new DalArticleTag()
            {
                ArticleId = articleTag.ArticleId,
                TagId = articleTag.TagId
            };
        }

        #endregion

        #region TagsBllMapper

        public static DalTag ToDalTag(this TagEntity tag)
        {
            return new DalTag()
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        public static TagEntity ToBllTag(this DalTag tag)
        {
            return new TagEntity()
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        #endregion

        #region BlogsBllMapper

        public static DalBlog ToDalBlog(this FullBlogEntity blog)
        {
            return new DalBlog()
            {
                Id = blog.Id,
                Name = blog.Name,
                UserId = blog.User.Id
            };
        }

        public static BlogEntity ToBllBlog(this DalBlog blog)
        {
            return new BlogEntity()
            {
                Id = blog.Id,
                Name = blog.Name,
                UserId = blog.UserId
            };
        }

        public static DalBlog ToDalBlog(this BlogEntity blog)
        {
            return new DalBlog()
            {
                Id = blog.Id,
                Name = blog.Name,
                UserId = blog.UserId
            };
        }
        #endregion
    }
}
