using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _4_Interface_Segregation_Principle.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(10)]
        public string Password { get; set; }

    }
}
