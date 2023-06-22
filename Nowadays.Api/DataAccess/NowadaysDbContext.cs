using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nowadays.Api.Entities;
using Nowadays.Api.Entities.Common;

namespace Nowadays.Api.DataAccess
{
    public class NowadaysDbContext:DbContext
    {
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseNpgsql("Host=35.86.123.26; Database=DbNowaDays; Username=postgres; Password=postgres");
        //     base.OnConfiguring(optionsBuilder);
        // }
        
        public NowadaysDbContext()
        {
            
        }
        public NowadaysDbContext(DbContextOptions<NowadaysDbContext> options):base(options)
        {
            
        }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Duty> Duties { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                 _ = data.State switch
                 {
                       EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                       EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                       _=> DateTime.UtcNow
                 };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}