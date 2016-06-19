using System.Linq;

namespace ORM
{
    using System.Data.Entity;

    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("EntityModel")
        {
        }

        static EntityModel()
        {
            System.Data.Entity.Database.SetInitializer<EntityModel>(new CreateDatabaseIfNotExists<EntityModel>());
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleTag> ArticleTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)  
        {
            modelBuilder.Entity<Blog>()
                .HasRequired( c => c.User)
                .WithMany( e => e.Blogs)
                .HasForeignKey(e => e.UserId)                
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasRequired(c => c.User)
                .WithMany( e => e.Articles)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
