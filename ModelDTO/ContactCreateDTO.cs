﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDTO
{
    public class ContactCreateDTO
    {
        
        [Required]
        [StringLength(30)]
        public string FullName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        
    }
}
