using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFirstTracker.Data
{
    public class DomFamily : ContactInfo
    {
        [Key]
        public int DomFamId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "Home Study Completed")]
        public bool IsHomeStudyDone { get; set; }
       
        [Display(Name = "Date of Home Study")]
        public DateTime? HomeStudyDate { get; set; }

    }
}
