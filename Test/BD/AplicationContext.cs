using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.BD
{
    public class AplicationContext : DbContext
    {
        public static AplicationContext contex {get;private set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<QuestionAnswer> Questions { get; set; }
        public AplicationContext()
        {
            Database.EnsureCreated();
            contex = this;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-QKDTUFV\\SQLEXPRESS;Initial Catalog = RulePDD3; Integrated Security = True; Encrypt=True;Trust Server Certificate=True;");
        }
    }
}
