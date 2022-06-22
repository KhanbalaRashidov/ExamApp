using ExamApp.BAL.Abstract;
using ExamApp.DAL.Abstract;
using ExamApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.WebUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _studentService.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
           [Bind("StudentNumber,Name,Surname,Class")] Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await _studentService.AddStudent(student);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int? studentNumber)
        {
            if (studentNumber == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetByNumber(studentNumber);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? studentNumber)
        {
            if (studentNumber == null)
            {
                return NotFound();
            }
            var studentToUpdate = await _studentService.GetByNumber(studentNumber);
            if (await TryUpdateModelAsync<Student>(
                studentToUpdate,
                "",
                 s=>s.StudentNumber  , s => s.Name, s => s.Surname, s => s.Class))
            {
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(studentToUpdate);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? studentNumber, bool? saveChangesError = false)
        {
            if (studentNumber == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetByNumber(studentNumber);
            if (student == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(student);
        }
        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int studentNumber)
        {
            var student = await _studentService.GetByNumber(studentNumber);
            if (student == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await _studentService.DeleteStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { studentNumber = studentNumber, saveChangesError = true });
            }
        }
    }
}
