using FreeSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab05.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Loai> Loai { get; set; }
        public DbSet<HangHoa> HangHoa { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=EFCoreCodeFirst-QLBH;Integrated Security=True;");
        }
    }
}