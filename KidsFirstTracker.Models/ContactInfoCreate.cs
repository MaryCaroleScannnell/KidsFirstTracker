using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFirstTracker.Models
{
    public class ContactInfoCreate
    {
        [Display(Name = "Parent #1's Name")]
        public string Parent1Name { get; set; }

        [Display(Name = "Parent #2's Name")]
        public string Parent2Name { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
