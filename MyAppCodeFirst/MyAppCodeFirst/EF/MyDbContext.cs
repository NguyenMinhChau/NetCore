using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppCodeFirst.EF
{
    public class MyDbContext : DbContext
    {
        public DbSet<Loai> Loais { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
