/* 
 * Name:Ken Wang
 * uID: u1193853
 */
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            #region CourseSeed
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CId = 1,
                    Name = "Web Development",
                    Description = "Software architectures, programming models, and programming environments pertinent to developing web applications.  Topics include client-server model, multi-tier software architecture, client-side scripting (JavaScript), server-side programming (Servlets and JavaServer Pages), component reuse (JavaBeans), database connectivity (JDBC), and web servers.",
                    Dept = "CS",
                    Number = 4540,
                    Semester = "FA",
                    Year = 2019,
                    Email = "professor_jim@cs.utah.edu"
                },
                new Course
                {
                    CId = 2,
                    Name = "Algorithms",
                    Description = "This course provides an introduction to the problem of engineering computational efficiency into programs.Students will learn about classical algorithms(including sorting, searching, and graph traversal),data structures(including stacks, queues, linked lists, trees, hash tables, and graphs),and analysis of program space and time requirements.Students will complete extensive programming exercises that require the application of elementary techniques from software engineering.",
                    Dept = "CS",
                    Number = 2420,
                    Semester = "FA",
                    Year = 2019,
                    Email = "professor_jim@cs.utah.edu"
                },
                new Course
                {
                    CId = 3,
                    Name = "Software Practice I",
                    Description = "Practical exposure to the process of creating large software systems, including requirements specifications, design, implementation, testing, and maintenance. Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), software engineering techniques (time management, code, and documentation standards, source code management, object-oriented analysis and design), and team development practice. Much of the work will be in groups and will involve modifying preexisting software systems.",
                    Dept = "CS",
                    Number = 3500,
                    Semester = "FA",
                    Year = 2019,
                    Email = "professor_jim@cs.utah.edu"
                },
                new Course
                {
                    CId = 4,
                    Name = "Discrete Structures",
                    Description = "Introduction to propositional logic, predicate logic, formal logical arguments, finite sets, functions, relations, inductive proofs, recurrence relations, graphs, probability, and their applications to Computer Science.",
                    Dept = "CS",
                    Number = 2100,
                    Semester = "FA",
                    Year = 2019,
                    Email = "professor_mary@cs.utah.edu"
                },
                new Course
                {
                    CId = 5,
                    Name = "Computer Systems",
                    Description = "Introduction to computer systems from a programmer's point of view.  Machine level representations of programs, optimizing program performance, memory hierarchy, linking, exceptional control flow, measuring program performance, virtual memory, concurrent programming with threads, network programming.",
                    Dept = "CS",
                    Number = 4400,
                    Semester = "FA",
                    Year = 2019,
                    Email = "professor_mary@cs.utah.edu"
                },
                new Course
                {
                    CId = 6,
                    Name = "Software Practice I",
                    Description = "Practical exposure to the process of creating large software systems, including requirements specifications, design, implementation, testing, and maintenance. Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), software engineering techniques (time management, code, and documentation standards, source code management, object-oriented analysis and design), and team development practice. Much of the work will be in groups and will involve modifying preexisting software systems.",
                    Dept = "CS",
                    Number = 3500,
                    Semester = "FA",
                    Year = 2019,
                    Email = "professor_danny@cs.utah.edu"
                }
            );
            #endregion

            modelBuilder.Entity<LearningOutcome>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.LOS)
                    .HasForeignKey("CourseId");
            });

            #region LearningOutcomeSeed
            modelBuilder.Entity<LearningOutcome>().HasData(

            #region CS4540
                new LearningOutcome()
                {
                    CourseCId = 1,
                    LId = 1,
                    Name = "HTML CSS",
                    Description = "Construct web pages using modern HTML and CSS practices, including modern frameworks"
                },
                new LearningOutcome()
                {
                    CourseCId = 1,
                    LId = 2,
                    Name = "Create accessible web pages",
                    Description = "Define accessibility and utilize techniques to create accessible web pages"
                },
                new LearningOutcome()
                {
                    CourseCId = 1,
                    LId = 3,
                    Name = "MVC",
                    Description = "Outline and utilize MVC technologies across the “full-stack” of web design (including front-end, back-end, and databases) to create interesting web applications. Deploy an application to a “Cloud” provider."
                },
                new LearningOutcome()
                {
                    CourseCId = 1,
                    LId = 4,
                    Name = "Security model",
                    Description = "Describe the browser security model and HTTP; utilize techniques for data validation, secure session communication, cookies, single sign-on, and separate roles.  "
                },
                new LearningOutcome()
                {
                    CourseCId = 1,
                    LId = 5,
                    Name = "JavaScript ",
                    Description = "Utilize JavaScript for simple page manipulations and AJAX for more complex/complete “single-page” application."
                },
                new LearningOutcome()
                {
                    CourseCId = 1,
                    LId = 6,
                    Name = "Responsive pages",
                    Description = "Demonstrate how responsive techniques can be used to construct applications that are usable at a variety of page sizes.  Define and discuss responsive, reactive, and adaptive."
                },
                new LearningOutcome()
                {
                    CourseCId = 1,
                    LId = 7,
                    Name = "web-crawler",
                    Description = "Construct a simple web-crawler for validation of page functionality and data scraping."
                },
            #endregion

            #region CS4400
                new LearningOutcome()
                {
                    CourseCId = 5,
                    LId = 8,
                    Name = "Modern computing systems",
                    Description = "Explain the objectives and functions of abstraction layers in modern computing systems, including operating systems, programming languages, compilers, and applications"
                },
                new LearningOutcome()
                {
                    CourseCId = 5,
                    LId = 9,
                    Name = "Cross-layer communications",
                    Description = "Understand cross-layer communications and how each layer of abstraction is implemented in the next layer of abstraction (such as how C programs are translated into assembly code and how C library allocators are implemented in terms of operating system memory management)"
                },
                new LearningOutcome()
                {
                    CourseCId = 5,
                    LId = 10,
                    Name = "Performance",
                    Description = "Analyze how the performance characteristics of one layer of abstraction affect the layers above it (such as how caching and services of the operating system affect the performance of C programs)"
                },
                new LearningOutcome()
                {
                    CourseCId = 5,
                    LId = 11,
                    Name = "Memory Management",
                    Description = "Construct applications using operating-system concepts (such as processes, threads, signals, virtual memory, I/O)"
                },
                new LearningOutcome()
                {
                    CourseCId = 5,
                    LId = 12,
                    Name = "Multi-threading",
                    Description = "Synthesize operating-system and networking facilities to build concurrent, communicating applications"
                },
                new LearningOutcome()
                {
                    CourseCId = 5,
                    LId = 13,
                    Name = "Parallel",
                    Description = "Implement reliable concurrent and parallel programs using appropriate synchronization constructs"
                },
            #endregion

            #region CS3500-Jim
                new LearningOutcome()
                {
                    CourseCId = 3,
                    LId = 14,
                    Name = "Software systems",
                    Description = "Design and implement large and complex software systems (including concurrent software) through the use of process models (such as waterfall and agile), libraries (both standard and custom), and modern software development tools (such as debuggers, profilers, and revision control systems)"
                },
                new LearningOutcome()
                {
                    CourseCId = 3,
                    LId = 15,
                    Name = "Validation,testing",
                    Description = "Perform input validation and error handling, as well as employ advanced testing principles and tools to systematically evaluate software"
                },
                new LearningOutcome()
                {
                    CourseCId = 3,
                    LId = 16,
                    Name = "MVC",
                    Description = "Apply the model-view-controller pattern and event handling fundamentals to create a graphical user interface"
                },
                new LearningOutcome()
                {
                    CourseCId = 3,
                    LId = 17,
                    Name = "Services",
                    Description = "Exercise the client-server model and high-level networking APIs to build a web-based software system"
                },
                new LearningOutcome()
                {
                    CourseCId = 3,
                    LId = 18,
                    Name = "Database",
                    Description = "Operate a modern relational database to define relations, as well as store and retrieve data"
                },
                new LearningOutcome()
                {
                    CourseCId = 3,
                    LId = 19,
                    Name = "Peer Review",
                    Description = "Appreciate the collaborative nature of software development by discussing the benefits of peer code reviews"
                },
                #endregion

            #region CS3500-Danny
                new LearningOutcome()
                {
                    CourseCId = 6,
                    LId = 20,
                    Name = "Software systems",
                    Description = "Design and implement large and complex software systems (including concurrent software) through the use of process models (such as waterfall and agile), libraries (both standard and custom), and modern software development tools (such as debuggers, profilers, and revision control systems)"
                },
                new LearningOutcome()
                {
                    CourseCId = 6,
                    LId = 21,
                    Name = "Validation,testing",
                    Description = "Perform input validation and error handling, as well as employ advanced testing principles and tools to systematically evaluate software"
                },
                new LearningOutcome()
                {
                    CourseCId = 6,
                    LId = 22,
                    Name = "MVC",
                    Description = "Apply the model-view-controller pattern and event handling fundamentals to create a graphical user interface"
                },
                new LearningOutcome()
                {
                    CourseCId = 6,
                    LId = 23,
                    Name = "Services",
                    Description = "Exercise the client-server model and high-level networking APIs to build a web-based software system"
                },
                new LearningOutcome()
                {
                    CourseCId = 6,
                    LId = 24,
                    Name = "Database",
                    Description = "Operate a modern relational database to define relations, as well as store and retrieve data"
                },
                new LearningOutcome()
                {
                    CourseCId = 6,
                    LId = 25,
                    Name = "Peer Review",
                    Description = "Appreciate the collaborative nature of software development by discussing the benefits of peer code reviews"
                },
            #endregion

            #region CS2420
                new LearningOutcome()
                {
                    CourseCId = 2,
                    LId = 26,
                    Name = "Data Structures",
                    Description = "Implement, and analyze for efficiency, fundamental data structures (including lists, graphs, and trees) and algorithms (including searching, sorting, and hashing)"
                },
                new LearningOutcome()
                {
                    CourseCId = 2,
                    LId = 27,
                    Name = "Time Complexity",
                    Description = "Employ Big-O notation to describe and compare the asymptotic complexity of algorithms, as well as perform empirical studies to validate hypotheses about running time"
                },
                new LearningOutcome()
                {
                    CourseCId = 2,
                    LId = 28,
                    Name = "Abstract Data Types",
                    Description = "Recognize and describe common applications of abstract data types (including stacks, queues, priority queues, sets, and maps)"
                },
                new LearningOutcome()
                {
                    CourseCId = 2,
                    LId = 29,
                    Name = "Algorithm",
                    Description = "Apply algorithmic solutions to real-world data"
                },
                new LearningOutcome()
                {
                    CourseCId = 2,
                    LId = 30,
                    Name = "Generics",
                    Description = "Use generics to abstract over functions that differ only in their types"
                },
                new LearningOutcome()
                {
                    CourseCId = 2,
                    LId = 31,
                    Name = "Pair Programming",
                    Description = "Appreciate the collaborative nature of computer science by discussing the benefits of pair programming"
                },
            #endregion

            #region CS2100
                new LearningOutcome()
                {
                    CourseCId = 4,
                    LId = 32,
                    Name = "Predicates",
                    Description = "Use symbolic logic to model real-world situations by converting informal language statements to propositional and predicate logic expressions, as well as apply formal methods to propositions and predicates (such as computing normal forms and calculating validity)"
                },
                new LearningOutcome()
                {
                    CourseCId = 4,
                    LId = 33,
                    Name = "Recurrence relations",
                    Description = "Analyze problems to determine underlying recurrence relations, as well as solve such relations by rephrasing as closed formulas"
                },
                new LearningOutcome()
                {
                    CourseCId = 4,
                    LId = 34,
                    Name = "Sets and models",
                    Description = "Assign practical examples to the appropriate set, function, or relation model, while employing the associated terminology and operations)"
                },
                new LearningOutcome()
                {
                    CourseCId = 4,
                    LId = 35,
                    Name = "Counting",
                    Description = "Map real-world applications to appropriate counting formalisms, including permutations and combinations of sets, as well as exercise the rules of combinatorics (such as sums, products, and inclusion-exclusion)"
                },
                new LearningOutcome()
                {
                    CourseCId = 4,
                    LId = 36,
                    Name = "Probabilities",
                    Description = "Calculate probabilities of independent and dependent events, in addition to expectations of random variables"
                },
                new LearningOutcome()
                {
                    CourseCId = 4,
                    LId = 37,
                    Name = "Graph",
                    Description = "Illustrate by example the basic terminology of graph theory, as wells as properties and special cases (such as Eulerian graphs, spanning trees, isomorphism, and planarity)"
                },
                new LearningOutcome()
                {
                    CourseCId = 4,
                    LId = 38,
                    Name = "Proofs",
                    Description = "Employ formal proof techniques (such as direct proof, proof by contradiction, induction, and the pigeonhole principle) to construct sound arguments about properties of numbers, sets, functions, relations, and graphs"
                }
                #endregion
                      );
            #endregion
        }

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
        [Required]
        [EmailAddress]
        public string Email { get; set; }
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
        public Course Course { get; set; }
    }

}
