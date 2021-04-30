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
        [Display(Name = "Poland")]
        Poland =1,
        [Display(Name = "Ukraine")]
        Ukraine,
        [Display(Name = "Dominican Republic")]
        DominicanRepublic,
        [Display(Name = "Bulgaria")]
        Bulgaria,

    }
    public class IntFamily : ContactInfo
    {
        [Key]
        public int IntFamId { get; set; }

        public Guid OwnerId { get; set; }
        [Required]
        public Country Country { get; set; }

        [Display(Name = "USCIS Expiration")]
        public DateTime? USCISExpiration { get; set; }
    }
}
