using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlCreation.Entities;

namespace UrlCreation.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Url> DbSetUrl { get; set; }

        public IQueryable<Url> Urls
        {
            get
            {
                return this.DbSetUrl;
            }
        }

        public Url TryCodeUniqueness(string code)
        {
            return this.DbSetUrl.SingleOrDefault(x => x.Code == code);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Entity<Url>()
                .ToTable(nameof(Url)).HasKey(x => x.Code);

            //builder.Entity<Url>()
            //    .Property(x => x.Id).UseIdentityColumn();

            builder.Entity<Url>()
                .Property(x => x.Code).HasMaxLength(10).IsUnicode(false).IsRequired();

            builder.Entity<Url>()
               .Property(x => x.LongUrl).HasMaxLength(500).IsUnicode(true).IsRequired();

            //builder.Entity<Url>()
            //    .HasIndex(x => x.Code).IsUnique().IsClustered();
        }
    }
}
