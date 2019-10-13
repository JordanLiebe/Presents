using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DubAttendenceTracker.Models;

namespace DubAttendenceTracker.Models
{
    public class DubAttendenceTrackerContext : DbContext
    {
        public DubAttendenceTrackerContext (DbContextOptions<DubAttendenceTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<DubAttendenceTracker.Models.Event> Event { get; set; }

        public DbSet<DubAttendenceTracker.Models.Person> Person { get; set; }

        public DbSet<DubAttendenceTracker.Models.Attendence> Attendences { get; set; }
    }
}
