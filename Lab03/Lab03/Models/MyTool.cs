using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03.Models
{
    public class MyTool
    {
        public static string MaBaoMat(int length = 5)
        {
            var parttent = "zaqwsxcderfvbgtyhnmjukiol[]1234567890<>";
            var random = new Random();
            var sb = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                sb.Append(random.Next(0, parttent.Length));
            };
            //Lưu số ngẫu nhiên trên Server dùng Session
            return sb.ToString();
        }
    }
}
