/* 
 * Name:Ken Wang
 * uID: u1193853
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CS4540_A2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using CS4540_A2.Data;

namespace CS4540_A2.Controllers
{
    [Authorize(Roles = "Admin,Instructor,DepartmentChair")]
    public class CoursesController : Controller
    {
        private readonly LOSContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CoursesController(LOSContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize(Roles = "Admin,DepartmentChair")]
        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var Courses = await _context.Courses.OrderBy(course => course.Number).ToListAsync();
            
            Dictionary<Course, string> map = new Dictionary<Course, string>();
            foreach(Course c in Courses)
            {
                //Maybe not Every course has ONE professor?
                var Professor = await _userManager.FindByEmailAsync(c.Email);
                if(Professor == null)
                {
                    //Fake user
                    Professor = new IdentityUser("Undetermined");
                }
                map.Add(c, Professor.UserName);   
            }
            ViewData["CoursesMap"] = map;
            return View();
           // return View(await _context.Courses.ToListAsync());
        }

        // GET: Courses/Details?cId=1
        public async Task<IActionResult> Details(int cId)
        {
            var course = await _context.Courses
                .FirstOrDefaultAsync(m =>
               m.CId == cId);

            var LOS = await _context.LOS.Where(LO => LO.CourseCId == course.CId).ToListAsync();

            if (course == null)
            {
                return NotFound();
            }

            // Email in this course matches the current login's email 
            var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
            if(user == null)
            {
                return NotFound();
            }
            var userEmail = await _userManager.GetEmailAsync(user);
            var courseEmail = course.Email;
            
            // Instructor can't see the DCV page
            if(userEmail != courseEmail && (User.IsInRole("Instructor")))
            {
                Console.WriteLine(userEmail);
                Console.WriteLine(courseEmail);
                return View("../Shared/AccessDenied");
            }

            course.LOS = LOS;
            ViewData["Course"] = course;

            return View(course);
        }
        /* 
         *  Gets All the courses that belongs to such professor 
            Assumes ProfessorUserName is passed in as danny_kopta, which is the username.        
         */
        public async Task<IActionResult> DetailsProfessor(string ProfessorUserName)
        {
            /* Check User acceess */
            var Professor = await _userManager.FindByNameAsync(ProfessorUserName);
            // Checks bad parameter
            if(Professor == null)
            {
                return NotFound();
            }

            // Email in this course matches the current login's email 
            var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));

            // Instructor who is not the provided ProfessorUserName can't access
            // But admin and chair can see
            if(user.UserName != ProfessorUserName && User.IsInRole("Instructor"))
            {
                return View("../Shared/AccessDenied");
            }

            // At this point user is for sure to be the right professor or chair or admin
            // Unless there's duplicate names
            // Will consider so later
            var professorEmail = await _userManager.GetEmailAsync(Professor);

            // Get courses links to the email
            var courses = await _context.Courses
                .Where(m =>
               m.Email == professorEmail).OrderBy(course => course.Number).ToListAsync();

            if (courses == null)
            {
                return NotFound();
            }

            foreach(Course c in courses)
            {
                var LOS = await _context.LOS.Where(LO => LO.CourseCId == c.CId).ToListAsync();
                c.LOS = LOS;
            }
             
            ViewData["Courses"] = courses;
            ViewData["Name"] = ProfessorUserName;

            return View(courses);
        }

    }
}
