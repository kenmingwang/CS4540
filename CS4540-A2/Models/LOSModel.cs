using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS4540_A2.Models
{
    public class LOSContext : DbContext
    {
        public LOSContext(DbContextOptions<LOSContext> options)
            : base(options)
        { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<LearningOutcome> LOS { get; set; }
    }

    public class Course
    {
        [Key]
        public int CId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [StringLength(6)]
        public string Dept { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        [StringLength(2)]
        public string Semester { get; set; }
        [Required]
        public int Year { get; set; }
        public ICollection<LearningOutcome> LOS { get; set; }
    }

    public class LearningOutcome
    {
        [Key]
        public int LId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CourseCId { get; set; }
        [Required]
        public Course Course { get; set; }
    }
}
