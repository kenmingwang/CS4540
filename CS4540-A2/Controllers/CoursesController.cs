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
        /* Assumes ProfessorUserName is passed in as danny_kopta */
        public async Task<IActionResult> DetailsProfessor(string ProfessorUserName)
        {
            /* Check User acceess */
            var Professor = await _userManager.FindByIdAsync(ProfessorUserName);
            // Checks bad parameter
            if(Professor == null)
            {
                return NotFound();
            }

            // Email in this course matches the current login's email 
            var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));

            // Instructor who is not the provided ProfessorUserName can't access
            // But admin and chair can see
            if(user.UserName == ProfessorUserName && User.IsInRole("Instructor"))
            {
                return View("../Shared/AccessDenied");
            }

            // At this point user is for sure to be the professor
            // Unless there's duplicate names
            // Will consider so later
            var professorEmail = await _userManager.GetEmailAsync(user);

            // Get courses links to the email
            var courses = await _context.Courses
                .Where(m =>
               m.Email == professorEmail).ToListAsync();

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

            return View(courses);
        }

        [Authorize(Roles ="Admin")]
        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CId,Name,Description,Dept,Number,Semester,Year")] Course course)
        {
            if (id != course.CId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.CId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CId == id);
        }
    }
}
