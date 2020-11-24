using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mid.Models
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Calculation> Categories { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
             => optionsbuilder.UseMySql("server=localhost;port=3307;userid=root;password=;database=.NET_PROJECTDUB3;");

    }
}
