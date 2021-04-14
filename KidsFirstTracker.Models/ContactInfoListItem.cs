﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFirstTracker.Models
{
    public abstract class ContactInfoListItem
    {
        [Display(Name = "Parent #1's Name")]
        public string Parent1Name { get; set; }

        [Display(Name = "Parent #2's Name")]
        public string Parent2Name { get; set; }
        
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
    }
}
