using Cebulit.API.Core.Models;
using Cebulit.API.Models.Auth;
using Cebulit.API.Models.Products.PcParts;
using Microsoft.EntityFrameworkCore;

namespace Cebulit.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        
        public DbSet<Processor> Processors { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Memory> Memory { get; set; }
        public DbSet<GraphicsCard> GraphicsCards { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<PowerSupply> PowerSupplies { get; set; }
        public DbSet<Case> Cases { get; set; }
        
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Build> Builds { get; set; }
        public DbSet<UserBuild> UserBuilds { get; set; }
    }
}