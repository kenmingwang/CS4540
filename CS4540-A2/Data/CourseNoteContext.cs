using CS4540_A2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS4540_A2.Data
{
    public class CourseNoteContext : DbContext
    {
        public CourseNoteContext(DbContextOptions<CourseNoteContext> options)
            : base(options)
        { }

        public DbSet<CourseNote> CourseNotes{ get; set; }
    }

}
