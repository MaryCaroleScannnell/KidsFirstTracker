using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFirstTracker.Models
{
    public class HomeStudyCreate : ContactInfoCreate
    {
        [Display(Name = "Type of Home Study")]
        public Data.HomeStudyType TypeOfHomeStudy { get; set; }

        public string Agency { get; set; }
    }
}
