using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _02View.Models
{
    public class Member
    {
        [DisplayName ("使用者帳號")]
        [Required]
        public string UserId { get; set; }
        public string Pwd { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
    }
}