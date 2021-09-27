using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03.Models
{
    public class Member
    {
        public int ID { get; set; }
        [Display(Name = "Mã SV")]
        [Remote(action: "CheckSV", controller: "Member")]
        public string SinhVien { get; set; }
        [Display(Name = "Họ tên")]
        [MinLength(3, ErrorMessage = "Tối thiểu 3 kí tự")]
        [StringLength(100)]
        public string FullName { get; set; }
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Số tài khoản")]
        [CreditCard]
        [DataType(DataType.CreditCard)]
        public string CreditCard { get; set; }
        [Display(Name = "Thông tin thêm")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name ="Điểm số")]
        [RegularExpression("[0-10]")]
        public double Diem { get; set; }
        [Display(Name ="Hệ số")]
        [RegularExpression("[1-4]")]
        public int HeSo { get; set; }
        [Display(Name ="Mã bảo mật")]
        [Remote(action: "KiemTraMaBaoMat", controller: "Member")]
        public int MaBaoMat { get; set; }
    }
}
