using Microsoft.EntityFrameworkCore;

using MyMeds.Models;

namespace MyMeds.Data
{
    public class MyMedsContext : DbContext
    {
        public MyMedsContext(DbContextOptions<MyMedsContext> options)
            : base(options)
        {
        }

        public DbSet<MedicationModel> MedicationModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=.;Initial Catalog=MyMeds;Integrated Security=True;");
        }
    }
}
