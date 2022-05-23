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
                    .HasName("UQ__apiUser__2EEAD09C6191F808")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__apiUser__F3DBC5720D6DC048")
                    .IsUnique();

                entity.Property(e => e.AccountHash).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });

            modelBuilder.Entity<ApiUserInformation>(entity =>
            {
                entity.HasIndex(e => e.AccountHash)
                    .HasName("UQ__apiUserI__2EEAD09C900CF5FA")
                    .IsUnique();

                entity.Property(e => e.AccountHash).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.HasOne(d => d.AccountHashNavigation)
                    .WithOne(p => p.ApiUserInformation)
                    .HasPrincipalKey<ApiUser>(p => p.AccountHash)
                    .HasForeignKey<ApiUserInformation>(d => d.AccountHash)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_userdata_to_user");
            });

            modelBuilder.Entity<SessionModel>(entity =>
            {
                entity.HasIndex(e => e.SessionId)
                    .HasName("UQ__sessionM__23DB12CA4165C073")
                    .IsUnique();

                entity.Property(e => e.AccountHash).IsUnicode(false);

                entity.Property(e => e.SessionId).IsUnicode(false);

                entity.HasOne(d => d.AccountHashNavigation)
                    .WithMany(p => p.SessionModel)
                    .HasPrincipalKey(p => p.AccountHash)
                    .HasForeignKey(d => d.AccountHash)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usersession_to_user");
            });

            modelBuilder.Entity<UserSavedDemos>(entity =>
            {
                entity.Property(e => e.AccountHash).IsUnicode(false);

                entity.Property(e => e.DemoHash).IsUnicode(false);

                entity.Property(e => e.DemoTitle).IsUnicode(false);

                entity.HasOne(d => d.AccountHashNavigation)
                    .WithMany(p => p.UserSavedDemos)
                    .HasPrincipalKey(p => p.AccountHash)
                    .HasForeignKey(d => d.AccountHash)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_demoHash_to_user");
            });

            modelBuilder.Entity<UserSavedLessons>(entity =>
            {
                entity.Property(e => e.AccountHash).IsUnicode(false);

                entity.Property(e => e.LessonHash).IsUnicode(false);

                entity.Property(e => e.LessonTitle).IsUnicode(false);

                entity.HasOne(d => d.AccountHashNavigation)
                    .WithMany(p => p.UserSavedLessons)
                    .HasPrincipalKey(p => p.AccountHash)
                    .HasForeignKey(d => d.AccountHash)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_lessonHash_to_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
