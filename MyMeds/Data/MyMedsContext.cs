using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMeds.Models;

namespace MyMeds.Data
{
    public class MyMedsContext : DbContext
    {
        public MyMedsContext (DbContextOptions<MyMedsContext> options)
            : base(options)
        {
        }

        public DbSet<MyMeds.Models.Profile> Profile { get; set; }
    }
}
