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
