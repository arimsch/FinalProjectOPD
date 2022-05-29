using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<Student> Students { get;  set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<Lec> Lecs { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }

        public class EFBDContexFactory : IDesignTimeDbContextFactory<EFDBContext>
        {
            public EFDBContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=finalTaskDb;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));

                return new EFDBContext(optionsBuilder.Options);
            }
        }
    }
}
