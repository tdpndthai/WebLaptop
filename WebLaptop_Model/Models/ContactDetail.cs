using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLaptop_Model.Models
{
    [Table("ContactDetails")]
    public class ContactDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(250)]
        [Required]
        public string Name { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(250)]
        public string Email { get; set; }
        [StringLength(250)]
        public string Website { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        public string Others { get; set; }
        public double? Lat { get; set; } //vĩ độ
        public double? Lng { get; set; } //kinh độ
        public bool Status { get; set; }
    }
}
