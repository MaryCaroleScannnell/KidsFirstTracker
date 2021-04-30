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
        [Display(Name ="Domestic")]
        Domestic = 1,
        [Display(Name = "International")]
        International,
        [Display(Name = "Domestic Update")]
        DomUpdate,
        [Display(Name = "International Update")]
        InternationalUpdate,
        [Display(Name = "Addendum")]
        Addendum,
        [Display(Name = "Post Placement")]
        PostPlacement

    }

    public class HomeStudy : ContactInfo
    {


        [Key]
        public int HomeStudyId { get; set; }

        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "Type of Home Study")]
        public HomeStudyType TypeOfHomeStudy { get; set; }
        [Required]
        public string Agency { get; set; }

    }
}
