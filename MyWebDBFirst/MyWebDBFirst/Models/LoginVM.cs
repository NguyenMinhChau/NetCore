using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebDBFirst.Models
{
    public class LoginVM
    {
        [Required]
        [MaxLength(20)]
        [Display(Name ="Mã Khách Hàng")]
        public string MaKh { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }
    }
}
