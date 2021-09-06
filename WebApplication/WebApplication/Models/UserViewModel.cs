using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
