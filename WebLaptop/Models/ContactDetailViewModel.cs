using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLaptop.Models
{
    public class ContactDetailViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Tên không được trống")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "SDT không quá 50 kí tự")]
        public string Phone { get; set; }
        [MaxLength(250, ErrorMessage = "Email không quá 250 kí tự")]
        public string Email { get; set; }
        [MaxLength(250, ErrorMessage = "Email không quá 250 kí tự")]
        public string Website { get; set; }
        [MaxLength(250, ErrorMessage = "Email không quá 250 kí tự")]
        public string Address { get; set; }
        public string Others { get; set; }
        public double? Lat { get; set; } //vĩ độ
        public double? Lng { get; set; } //kinh độ
        public bool Status { get; set; }
    }
}