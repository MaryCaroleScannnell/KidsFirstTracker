using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFirstTracker.Data
{
    public enum Gender
    {
        Girl =1,
        Boy,
        Either,
    }
    public class Preference
    {
        [Key]
        public int PreferenceId { get; set; }
        [ForeignKey(nameof(DomFamily))]
        public int? DomFamId { get; set; }
        public virtual DomFamily DomFamily { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name ="Gender Preference")]
        public Gender GenderPreference { get; set; }
        [Required]
        [Display(Name ="Youngest Preferred Age")]
        public int MinAge { get; set; }
        [Required]
        [Display(Name = "Oldest Preferred Age")]
        public int MaxAge { get; set; }
        [Required]
        [Display(Name = "Race Preference")]
        public string RacePreference { get; set; }
        [Display(Name = "Open to Out of State")]
        public bool AreTheyOkayWithOtherStates { get; set; }




    }
}
