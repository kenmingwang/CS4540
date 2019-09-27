using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS4540A2.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Dept = table.Column<string>(maxLength: 6, nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Semester = table.Column<string>(maxLength: 2, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CId);
                });

            migrationBuilder.CreateTable(
                name: "LOS",
                columns: table => new
                {
                    LId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CourseCId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOS", x => x.LId);
                    table.ForeignKey(
                        name: "FK_LOS_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CId", "Dept", "Description", "Email", "Name", "Number", "Semester", "Year" },
                values: new object[,]
                {
                    { 1, "CS", "Software architectures, programming models, and programming environments pertinent to developing web applications.  Topics include client-server model, multi-tier software architecture, client-side scripting (JavaScript), server-side programming (Servlets and JavaServer Pages), component reuse (JavaBeans), database connectivity (JDBC), and web servers.", "professor_jim@cs.utah.edu", "Web Development", 4540, "FA", 2019 },
                    { 2, "CS", "This course provides an introduction to the problem of engineering computational efficiency into programs.Students will learn about classical algorithms(including sorting, searching, and graph traversal),data structures(including stacks, queues, linked lists, trees, hash tables, and graphs),and analysis of program space and time requirements.Students will complete extensive programming exercises that require the application of elementary techniques from software engineering.", "professor_jim@cs.utah.edu", "Algorithms", 2420, "FA", 2019 },
                    { 3, "CS", "Practical exposure to the process of creating large software systems, including requirements specifications, design, implementation, testing, and maintenance. Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), software engineering techniques (time management, code, and documentation standards, source code management, object-oriented analysis and design), and team development practice. Much of the work will be in groups and will involve modifying preexisting software systems.", "professor_jim@cs.utah.edu", "Software Practice I", 3500, "FA", 2019 },
                    { 4, "CS", "Introduction to propositional logic, predicate logic, formal logical arguments, finite sets, functions, relations, inductive proofs, recurrence relations, graphs, probability, and their applications to Computer Science.", "professor_mary@cs.utah.edu", "Discrete Structures", 2100, "FA", 2019 },
                    { 5, "CS", "Introduction to computer systems from a programmer's point of view.  Machine level representations of programs, optimizing program performance, memory hierarchy, linking, exceptional control flow, measuring program performance, virtual memory, concurrent programming with threads, network programming.", "professor_mary@cs.utah.edu", "Computer Systems", 4400, "FA", 2019 },
                    { 6, "CS", "Practical exposure to the process of creating large software systems, including requirements specifications, design, implementation, testing, and maintenance. Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), software engineering techniques (time management, code, and documentation standards, source code management, object-oriented analysis and design), and team development practice. Much of the work will be in groups and will involve modifying preexisting software systems.", "professor_danny@cs.utah.edu", "Software Practice I", 3500, "FA", 2019 }
                });

            migrationBuilder.InsertData(
                table: "LOS",
                columns: new[] { "LId", "CourseCId", "CourseId", "Description", "Name" },
                values: new object[,]
                {
                    { 21, 6, null, "Perform input validation and error handling, as well as employ advanced testing principles and tools to systematically evaluate software", "Validation,testing" },
                    { 22, 6, null, "Apply the model-view-controller pattern and event handling fundamentals to create a graphical user interface", "MVC" },
                    { 23, 6, null, "Exercise the client-server model and high-level networking APIs to build a web-based software system", "Services" },
                    { 24, 6, null, "Operate a modern relational database to define relations, as well as store and retrieve data", "Database" },
                    { 25, 6, null, "Appreciate the collaborative nature of software development by discussing the benefits of peer code reviews", "Peer Review" },
                    { 26, 2, null, "Implement, and analyze for efficiency, fundamental data structures (including lists, graphs, and trees) and algorithms (including searching, sorting, and hashing)", "Data Structures" },
                    { 27, 2, null, "Employ Big-O notation to describe and compare the asymptotic complexity of algorithms, as well as perform empirical studies to validate hypotheses about running time", "Time Complexity" },
                    { 28, 2, null, "Recognize and describe common applications of abstract data types (including stacks, queues, priority queues, sets, and maps)", "Abstract Data Types" },
                    { 31, 2, null, "Appreciate the collaborative nature of computer science by discussing the benefits of pair programming", "Pair Programming" },
                    { 30, 2, null, "Use generics to abstract over functions that differ only in their types", "Generics" },
                    { 20, 6, null, "Design and implement large and complex software systems (including concurrent software) through the use of process models (such as waterfall and agile), libraries (both standard and custom), and modern software development tools (such as debuggers, profilers, and revision control systems)", "Software systems" },
                    { 32, 4, null, "Use symbolic logic to model real-world situations by converting informal language statements to propositional and predicate logic expressions, as well as apply formal methods to propositions and predicates (such as computing normal forms and calculating validity)", "Predicates" },
                    { 33, 4, null, "Analyze problems to determine underlying recurrence relations, as well as solve such relations by rephrasing as closed formulas", "Recurrence relations" },
                    { 34, 4, null, "Assign practical examples to the appropriate set, function, or relation model, while employing the associated terminology and operations)", "Sets and models" },
                    { 35, 4, null, "Map real-world applications to appropriate counting formalisms, including permutations and combinations of sets, as well as exercise the rules of combinatorics (such as sums, products, and inclusion-exclusion)", "Counting" },
                    { 36, 4, null, "Calculate probabilities of independent and dependent events, in addition to expectations of random variables", "Probabilities" },
                    { 29, 2, null, "Apply algorithmic solutions to real-world data", "Algorithm" },
                    { 19, 3, null, "Appreciate the collaborative nature of software development by discussing the benefits of peer code reviews", "Peer Review" },
                    { 16, 3, null, "Apply the model-view-controller pattern and event handling fundamentals to create a graphical user interface", "MVC" },
                    { 17, 3, null, "Exercise the client-server model and high-level networking APIs to build a web-based software system", "Services" },
                    { 1, 1, null, "Construct web pages using modern HTML and CSS practices, including modern frameworks", "HTML CSS" },
                    { 2, 1, null, "Define accessibility and utilize techniques to create accessible web pages", "Create accessible web pages" },
                    { 3, 1, null, "Outline and utilize MVC technologies across the “full-stack” of web design (including front-end, back-end, and databases) to create interesting web applications. Deploy an application to a “Cloud” provider.", "MVC" },
                    { 4, 1, null, "Describe the browser security model and HTTP; utilize techniques for data validation, secure session communication, cookies, single sign-on, and separate roles.  ", "Security model" },
                    { 5, 1, null, "Utilize JavaScript for simple page manipulations and AJAX for more complex/complete “single-page” application.", "JavaScript " },
                    { 6, 1, null, "Demonstrate how responsive techniques can be used to construct applications that are usable at a variety of page sizes.  Define and discuss responsive, reactive, and adaptive.", "Responsive pages" },
                    { 7, 1, null, "Construct a simple web-crawler for validation of page functionality and data scraping.", "web-crawler" },
                    { 18, 3, null, "Operate a modern relational database to define relations, as well as store and retrieve data", "Database" },
                    { 8, 5, null, "Explain the objectives and functions of abstraction layers in modern computing systems, including operating systems, programming languages, compilers, and applications", "Modern computing systems" },
                    { 10, 5, null, "Analyze how the performance characteristics of one layer of abstraction affect the layers above it (such as how caching and services of the operating system affect the performance of C programs)", "Performance" },
                    { 11, 5, null, "Construct applications using operating-system concepts (such as processes, threads, signals, virtual memory, I/O)", "Memory Management" },
                    { 12, 5, null, "Synthesize operating-system and networking facilities to build concurrent, communicating applications", "Multi-threading" },
                    { 13, 5, null, "Implement reliable concurrent and parallel programs using appropriate synchronization constructs", "Parallel" },
                    { 14, 3, null, "Design and implement large and complex software systems (including concurrent software) through the use of process models (such as waterfall and agile), libraries (both standard and custom), and modern software development tools (such as debuggers, profilers, and revision control systems)", "Software systems" },
                    { 15, 3, null, "Perform input validation and error handling, as well as employ advanced testing principles and tools to systematically evaluate software", "Validation,testing" },
                    { 37, 4, null, "Illustrate by example the basic terminology of graph theory, as wells as properties and special cases (such as Eulerian graphs, spanning trees, isomorphism, and planarity)", "Graph" },
                    { 9, 5, null, "Understand cross-layer communications and how each layer of abstraction is implemented in the next layer of abstraction (such as how C programs are translated into assembly code and how C library allocators are implemented in terms of operating system memory management)", "Cross-layer communications" },
                    { 38, 4, null, "Employ formal proof techniques (such as direct proof, proof by contradiction, induction, and the pigeonhole principle) to construct sound arguments about properties of numbers, sets, functions, relations, and graphs", "Proofs" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LOS_CourseId",
                table: "LOS",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOS");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
