using System.ComponentModel.DataAnnotations;

namespace Bai_Thuc_Hanh_1.Models
{
    public class Student
    {
        public int Id { get; set; }//Mã sinh viên

        //[Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải từ 4 đến 100 ký tự")]
        [Required]
        public string? Name { get; set; } //Họ tên

        //[Required(ErrorMessage = "Email bắt buộc phải được nhập")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        //[Required(ErrorMessage = "Email bắt buộc phải nhập")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email phải có đuôi gmail.com")]
        [Required]
        public string? Email { get; set; } //Email

        //[StringLength(100, MinimumLength = 8)]
        [Required]
        //[Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Mật khẩu phải có ít nhất 1 chữ hoa, 1 chữ thường, 1 số và 1 ký tự đặc biệt")]
        public string? Password { get; set; }//Mật khẩu

        [Required]
        //[Required(ErrorMessage = "Vui lòng chọn ngành học")]
        public Branch? Branch { get; set; }//Ngành học

        [Required]
        //[Required(ErrorMessage = "Vui lòng chọn giới tính")]
        public Gender? Gender { get; set; }//Giới tính
        public bool IsRegular { get; set; }//Hệ: true-chính qui, false-phi cq

        [DataType(DataType.MultilineText)]
        [Required]
        //[Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string? Address { get; set; }//Địa chi

        //[Required(ErrorMessage = "Ngày sinh bắt buộc phải nhập")]
        [Range(typeof(DateTime),"01/01/1963","31/12/2005")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBorth { get; set; }//Ngày sinh
        public string? Avatar { get; set; } // Tên file ảnh đại diện

        //[Required(ErrorMessage = "Điểm không được để trống")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0")]
        public double Score { get; set; } // Điểm
    }
}
