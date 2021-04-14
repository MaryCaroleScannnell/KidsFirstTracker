using KidsFirstTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFirstTracker.Models
{
    public class IntFamilyCreate : ContactInfoCreate
    {
        public Country Country { get; set; }

        [Display(Name = "USCIS Expiration")]
        public DateTime? USCISExpiration { get; set; }
    }
}
