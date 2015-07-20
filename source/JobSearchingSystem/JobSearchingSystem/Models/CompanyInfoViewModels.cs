using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobSearchingSystem.Models
{
    public class CoInUpdateViewModel
    {
        public string recuiterId { get; set; }
        public string logoURL { get; set; }
        [Required(ErrorMessage = "Thông tin này bắt buộc")]
        [StringLength(100, ErrorMessage = "Nội dung nhập vào không vượt quá 100 kí tự.")]
        public string company { get; set; }
        public string address { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string phoneNumber { get; set; }
        public string description { get; set; }
        public IEnumerable<City> cities { get; set; }

    }
}