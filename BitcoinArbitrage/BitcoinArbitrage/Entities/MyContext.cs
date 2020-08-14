using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinArbitrage.Entities
{
    public class MyContext: DbContext
    {
        public DbSet<ArbitrageData> arbitrageData { get; set; }

        public MyContext(DbContextOptions<MyContext> options): base(options)
        {
             Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user id=root;Password=Ernst123?;database=ArbitrageDB");
            }
        }
    }
}
