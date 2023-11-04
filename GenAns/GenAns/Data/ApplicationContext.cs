using GenAns.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Net;

namespace GenAns.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<MineralEntity> Minerals { get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<RockEntity> Rocks { get; set; }
        public DbSet<SpecificationEntity> Specifications { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
