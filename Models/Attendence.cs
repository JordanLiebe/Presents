using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DubAttendenceTracker.Models
{
    public class Attendence
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Person")]
        public int PersonId { get; set; }
        [Required]
        [Display(Name = "Event")]
        public int EventId { get; set; }
    }
}
