using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFirstTracker.Data
{
    public enum HomeStudyType
    {
        Domestic = 1,
        International,
        DomUpdate,
        InternationalUpdate,
        Addendum,
        PostPlacement,

    }

    public class HomeStudy
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
        [Display(Name = "Type of Home Study")]
        public HomeStudyType TypeOfHomeStudy { get; set; }
        [Required]
        public string Agency { get; set; }

    }
}
