using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLaptop.Models
{
    public class FeedbackViewModel
    {
        public int ID { get; set; }
        [MaxLength(250,ErrorMessage ="Tên không được quá 250 kí tự")]
        [Required(ErrorMessage ="Tên phải nhập")]
        public string Name { get; set; }
        [MaxLength(250, ErrorMessage = "Email không được quá 250 kí tự")]
        public string Email { get; set; }
        [MaxLength(500, ErrorMessage = "Thông điệp không được quá 500 kí tự")]
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required(ErrorMessage ="Chọn trạng thái")]
        public bool Status { get; set; }

        public ContactDetailViewModel ContactDetailViewModel { get; set; }
    }
}