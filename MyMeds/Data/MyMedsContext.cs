using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMeds.Models;

namespace MyMeds.Data
{
    public class MyMedsContext : DbContext
    {
        public MyMedsContext(DbContextOptions<MyMedsContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Logon> Logons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=.;Initial Catalog=MyMeds;Integrated Security=True;");
        }

    }
}
