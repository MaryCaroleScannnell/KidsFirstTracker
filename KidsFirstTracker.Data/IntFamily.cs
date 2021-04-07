using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFirstTracker.Data
{
    public enum Country
    {
        Poland =1,
        Ukraine,
        DominicanRepublic,
        Bulgaria,

    }
    public class IntFamily
    {
        [Key]
        public int IntFamId { get; set; }
        [Required]
        [Display(Name = "Parent #1's Name")]
        public string Parent1Name { get; set; }

        [Display(Name = "Parent #2's Name")]
        public string Parent2Name { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Country Country { get; set; }

        [Display(Name = "USCIS Expiration")]
        public DateTime USCISExpiration { get; set; }
    }
}
