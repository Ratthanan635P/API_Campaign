using Api_Campaign.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Api_Campaign.Context
{
	public class CampaignContext : DbContext
    {
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignDetailByCategory> CampaignDetailByCategory { get; set; }
        public DbSet<CampaignDetailByProduct> CampaignDetailByProduct { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=xamaring3.dookdik.me;Database=CampaignDB;Trusted_Connection=True;User Id=SA;Password=P@ssw0rd;Integrated Security=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
