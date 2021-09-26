using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab01.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double SoLuong { get; set; }
        public double Price { get; set; }
        public double ThanhTien => SoLuong * Price;
    }
}
