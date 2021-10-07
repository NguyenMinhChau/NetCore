using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03.Models
{
    public enum Gender { Male,Femal}
    public class Employee
    {
        public int ID { get; set; }
        [Display(Name = "Mã nhân viên")]
        [Remote(action: "CheckEmployeeNo", controller: "Employee")]
        public string EmployeeNo { get; set; }
        [Display(Name = "Họtên")]
        [MinLength(3, ErrorMessage = "Tối thiểu 3 kí tự")] 
        [StringLength(100)]
        public string FullName { get; set; }
        [Display(Name = "Email")] 
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Website")] 
        [Url]
        public string Website { get; set; }
        [Display(Name = "Ngày sinh")]
        [BirthDateCheck]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Giới tính")] 
        public Gender Gender { get; set; }
        [Display(Name = "Lương")] 
        [Range(0, 10000000)] 
        public double Salary { get; set; }
        [Display(Name = "Bán thời gian")] 
        public bool IsPartTime { get; set; }
        [Display(Name = "Địa chỉ")] 
        [RegularExpression("[a-zA-Z 0-9]*")] 
        public string Address { get; set; }
        [Display(Name = "Điện thoại")] 
        [RegularExpression("0[3789][0-9]{8}")] 
        public string Phone { get; set; }
        [Display(Name = "Sốtài khoản")] 
        [CreditCard] 
        [DataType(DataType.CreditCard)] 
        public string CreditCard { get; set; }
        [Display(Name = "Thông tin thêm")] 
        [DataType(DataType.MultilineText)] 
        public string Description { get; set; }
        public class BirthDateCheckAttribute : ValidationAttribute
        {
            public BirthDateCheckAttribute() : base("Ngày sinh không hợp lệ") { }
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var model = validationContext.ObjectInstance as Employee;
                if(model == null)
                {
                    throw new ArgumentException("Tham số truyền vào không đúng");
                }
                if(DateTime.Now.Year - model.BirthDate.Year < 10)
                {
                    return new ValidationResult("Chưa đủ 10 tuổi");
                }
                return ValidationResult.Success;
            }
        }
    }
}
