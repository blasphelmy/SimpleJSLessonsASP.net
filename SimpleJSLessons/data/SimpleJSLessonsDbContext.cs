using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SimpleJSLessons.Models;

namespace SimpleJSLessons.data
{
    public partial class SimpleJSLessonsDbContext : DbContext
    {
        public SimpleJSLessonsDbContext()
        {
        }

        public SimpleJSLessonsDbContext(DbContextOptions<SimpleJSLessonsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApiUser> ApiUser { get; set; }
        public virtual DbSet<ApiUserInformation> ApiUserInformation { get; set; }
        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<CommentsTable> CommentsTable { get; set; }
        public virtual DbSet<DataDataTable> DataDataTable { get; set; }
        public virtual DbSet<DataTable> DataTable { get; set; }
        public virtual DbSet<LikesTable> LikesTable { get; set; }
        public virtual DbSet<SessionModel> SessionModel { get; set; }
        public virtual DbSet<UserSavedDemos> UserSavedDemos { get; set; }
        public virtual DbSet<UserSavedLessons> UserSavedLessons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SimpleJSLessonsAPIData;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiUser>(entity =>
            {
                entity.HasIndex(e => e.AccountHash)
                    .HasName("UQ__apiUser__2EEAD09CBDBA9FF4")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__apiUser__F3DBC572B8FED14C")
                    .IsUnique();

                entity.Property(e => e.AccountHash).IsUnicode(false);

                entity.Property(e => e.ProfileData).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });

            modelBuilder.Entity<ApiUserInformation>(entity =>
            {
                entity.HasIndex(e => e.AccountHash)
                    .HasName("UQ__apiUserI__2EEAD09C43BA11FB")
                    .IsUnique();

                entity.Property(e => e.AccountHash).IsUnicode(false);

                entity.Property(e => e.CtclinkId).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.HasOne(d => d.AccountHashNavigation)
                    .WithOne(p => p.ApiUserInformation)
                    .HasPrincipalKey<ApiUser>(p => p.AccountHash)
                    .HasForeignKey<ApiUserInformation>(d => d.AccountHash)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_userdata_to_user");
            });

            modelBuilder.Entity<Authors>(entity =>
            {
                entity.Property(e => e.DataHash).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.DataHashNavigation)
                    .WithMany(p => p.Authors)
                    .HasPrincipalKey(p => p.DataHash)
                    .HasForeignKey(d => d.DataHash)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AuthorsToData");
            });

            modelBuilder.Entity<CommentsTable>(entity =>
            {
                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.CommentAuthorUsername).IsUnicode(false);

                entity.Property(e => e.Datahash).IsUnicode(false);
            });

            modelBuilder.Entity<DataDataTable>(entity =>
            {
                entity.HasIndex(e => new { e.UploadedBy, e.DataHash })
                    .HasName("uniqueImgToData")
                    .IsUnique();

                entity.Property(e => e.DataHash).IsUnicode(false);

                entity.Property(e => e.ImageData).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.UploadedBy).IsUnicode(false);

                entity.HasOne(d => d.DataHashNavigation)
                    .WithMany(p => p.DataDataTable)
                    .HasPrincipalKey(p => p.DataHash)
                    .HasForeignKey(d => d.DataHash)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("validDataReference");
            });

            modelBuilder.Entity<DataTable>(entity =>
            {
                entity.HasIndex(e => e.DataHash)
                    .HasName("UQ__DataTabl__13869B63FA812ACE")
                    .IsUnique();

                entity.Property(e => e.Data).IsUnicode(false);

                entity.Property(e => e.DataHash).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<LikesTable>(entity =>
            {
                entity.HasIndex(e => new { e.DataHash, e.Username })
                    .HasName("unique_likes")
                    .IsUnique();

                entity.Property(e => e.DataHash).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.LikesTable)
                    .HasPrincipalKey(p => p.Username)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reference_to_realuser");
            });

            modelBuilder.Entity<SessionModel>(entity =>
            {
                entity.Property(e => e.AccountHash).IsUnicode(false);

                entity.Property(e => e.SessionId).IsUnicode(false);

                entity.HasOne(d => d.AccountHashNavigation)
                    .WithMany(p => p.SessionModel)
                    .HasPrincipalKey(p => p.AccountHash)
                    .HasForeignKey(d => d.AccountHash)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SessionModel_to_apiUser");
            });

            modelBuilder.Entity<UserSavedDemos>(entity =>
            {
                entity.HasIndex(e => new { e.AccountHash, e.DemoHash })
                    .HasName("unique_demo_to_user")
                    .IsUnique();

                entity.Property(e => e.AccountHash).IsUnicode(false);

                entity.Property(e => e.DemoHash).IsUnicode(false);

                entity.Property(e => e.DemoTitle).IsUnicode(false);

                entity.HasOne(d => d.AccountHashNavigation)
                    .WithMany(p => p.UserSavedDemos)
                    .HasPrincipalKey(p => p.AccountHash)
                    .HasForeignKey(d => d.AccountHash)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_accountHash_to_user");

                entity.HasOne(d => d.DemoHashNavigation)
                    .WithMany(p => p.UserSavedDemos)
                    .HasPrincipalKey(p => p.DataHash)
                    .HasForeignKey(d => d.DemoHash)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_demohash_to_dataTable");
            });

            modelBuilder.Entity<UserSavedLessons>(entity =>
            {
                entity.HasIndex(e => new { e.AccountHash, e.LessonHash })
                    .HasName("unique_lesson_to_user")
                    .IsUnique();

                entity.Property(e => e.AccountHash).IsUnicode(false);

                entity.Property(e => e.LessonHash).IsUnicode(false);

                entity.Property(e => e.LessonTitle).IsUnicode(false);

                entity.HasOne(d => d.AccountHashNavigation)
                    .WithMany(p => p.UserSavedLessons)
                    .HasPrincipalKey(p => p.AccountHash)
                    .HasForeignKey(d => d.AccountHash)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_lessonHash_to_user");

                entity.HasOne(d => d.LessonHashNavigation)
                    .WithMany(p => p.UserSavedLessons)
                    .HasPrincipalKey(p => p.DataHash)
                    .HasForeignKey(d => d.LessonHash)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_lessonHash_to_dataTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
