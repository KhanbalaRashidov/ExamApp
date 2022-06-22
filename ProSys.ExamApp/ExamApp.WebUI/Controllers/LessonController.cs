using ExamApp.BAL.Abstract;
using ExamApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.WebUI.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _lessonService.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
           [Bind("StudentNumber,Name,Surname,Class")] Lesson lesson)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await _lessonService.AddLesson(lesson);
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
            return View(lesson);
        }

        public async Task<IActionResult> Edit(string? lessonCode)
        {
            if (lessonCode == null)
            {
                return NotFound();
            }

            var student = await _lessonService.GetByLessonCode(lessonCode);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(string? lessonCode)
        {
            if (lessonCode == null)
            {
                return NotFound();
            }
            var lessonToUpdate = await _lessonService.GetByLessonCode(lessonCode);
            if (await TryUpdateModelAsync<Lesson>(
                lessonToUpdate,
                "",
                 s => s.LessonCode, s => s.LessonName, s => s.Class, s => s.TeacherName, s=>s.TeacherSurname))
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
            return View(lessonToUpdate);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(string? lessonCode, bool? saveChangesError = false)
        {
            if (lessonCode == null)
            {
                return NotFound();
            }

            var lesson = await _lessonService.GetByLessonCode(lessonCode);
            if (lesson == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(lesson);
        }
        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string lessonCode)
        {
            var lesson = await _lessonService.GetByLessonCode(lessonCode);
            if (lesson == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await _lessonService.DeleteLesson(lesson);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { lessonCode = lessonCode, saveChangesError = true });
            }
        }
    }
}
