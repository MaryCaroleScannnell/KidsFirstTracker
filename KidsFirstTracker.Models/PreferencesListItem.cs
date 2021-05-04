using KidsFirstTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFirstTracker.Models
{
    public class PreferencesListItem
    {
        [Display(Name ="Preference ID")]
        public int PreferenceId { get; set; }
        [Display(Name = "Gender Preference")]
        public Gender GenderPreference { get; set; }
       
        [Display(Name = "Youngest Preferred Age")]
        public int MinAge { get; set; }
       
        [Display(Name = "Oldest Preferred Age")]
        public int MaxAge { get; set; }
        
        [Display(Name = "Race Preference")]
        public string RacePreference { get; set; }
        [Display(Name = "Open to Out of State")]
        public bool AreTheyOkayWithOtherStates { get; set; }

        public int? DomFamId { get; set; }
    }
}
