using Microsoft.EntityFrameworkCore;
using PerformanceTesterCSS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceTesterCSS.Entities
{
    public class DbCtx : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(b => b.Email)
                .IsUnique();

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(bool))
                    {
                        property.SetValueConverter(new BoolToIntConverter());
                    }
                }
            }

            //modelBuilder.Seed();
        }

        public DbCtx(DbContextOptions<DbCtx> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ConfigurationRecord> ConfigurationRecords { get; set; }
        public virtual DbSet<FailedJob> FailedJobs { get; set; }
        public virtual DbSet<DocumentFile> DocumentFiles { get; set; }
        public virtual DbSet<ImageInfo> ImageInfos { get; set; }
        public virtual DbSet<InAppMessage> InAppMessages { get; set; }
        public virtual DbSet<LogRecord> LogRecords { get; set; }
        public virtual DbSet<Migration> Migrations { get; set; }
        public virtual DbSet<NewsMessage> NewsMessages { get; set; }
        public virtual DbSet<Paper> Papers { get; set; }
        public virtual DbSet<PaperVersion> PaperVersions { get; set; }
        public virtual DbSet<Participation> Participations { get; set; }
        public virtual DbSet<PasswordReset> PasswordResets { get; set; }
        public virtual DbSet<Presence> Presences { get; set; }
        public virtual DbSet<ReferralRecord> ReferralRecords { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<ShoutboxMessage> ShoutboxMessages { get; set; }
        public virtual DbSet<UserAdminPrivileges> UserAdminPrivileges { get; set; }
    }
}
