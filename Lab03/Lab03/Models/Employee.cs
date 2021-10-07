using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lab03.Models
{
    public enum Gender { Male,Femal}
    public class Employee
    {
        public Guid? ID { get; set; }


        [Display(Name = "Mã nhân viên")]
        [Remote(action: "CheckEmployeeNo", controller: "Employee")]
        public string EmployeeNo { get; set; }


        [Display(Name = "Họ tên")]
        [MinLength(3, ErrorMessage = "Tối thiểu 3 kí tự")] 
        [StringLength(100)]
        public string FullName { get; set; }


        [Display(Name = "Email")] 
        [EmailAddress]
        [Required]
        public string Email { get; set; }


        [Display(Name = "Website")] 
        [Url]
        public string Website { get; set; }

        [Display(Name = "Ngày sinh")]
        //[BirthDateCheck]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


        [Display(Name = "Giới tính")] 
        public Gender? Gender { get; set; }

        
        [Display(Name = "Lương")] 
        [Range(0, 10000000)] 
        public double Salary { get; set; }


        [Display(Name = "Bán thời gian")] 
        public bool IsPartTime { get; set; }


        [Display(Name = "Địa chỉ")] 
        [RegularExpression("[a-zA-Z 0-9]*")] 
        public string Address { get; set; }

    
        [Display(Name = "Điện thoại")] 
        [RegularExpression("0[35789][0-9]{8}")] 
        public string Phone { get; set; }

        
        [Display(Name = "Số tài khoản")] 
        // Sử dụng 1 trong 2
        [CreditCard] 
        //[DataType(DataType.CreditCard)] 
        public string CreditCard { get; set; }


        [Display(Name = "Thông tin thêm")] 
        [DataType(DataType.MultilineText)] 
        public string Description { get; set; }



        public class BirthDateCheckAttribute : ValidationAttribute
        {
            public BirthDateCheckAttribute() : base("Ngày sinh không hợp lệ") { }
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                try
                {
                    var dob = (DateTime)value;
                    if (dob > DateTime.Now)
                    {
                        return new ValidationResult("Ngày sinh không hợp lệ");
                    }
                    return ValidationResult.Success;
                }
                catch
                {
                    return new ValidationResult("Ngày sinh không hợp lệ");
                }
            }
        }


        // Sync
        public int Test01()
        {
            Thread.Sleep(2000);
            return 10;
        }
        public string Test02()
        {
            Thread.Sleep(3000);
            return "hello";
        }
        // Async
        public async Task<int> Test01Async()
        {
            await Task.Delay(2000);
            return 10;
        }
        public async Task<string> Test02Async()
        {
            await Task.Delay(3000);
            return "hello";
        }
        // kiểu null
        public async Task Test03Async()
        {
            await Task.Delay(4000);
            return;
        }
    }
}
