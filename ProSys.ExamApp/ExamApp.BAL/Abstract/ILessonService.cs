using ExamApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.BAL.Abstract
{
    public interface ILessonService
    {
        Task<List<Lesson>> GetAll();
        Task<Lesson> GetByLessonCode(string lessonCode);
        Task AddLesson(Lesson lesson);
        Task UpdateLesson(Lesson lesson);
        Task DeleteLesson(Lesson lesson);
    }
}
