using ExamApp.BAL.Abstract;
using ExamApp.DAL.Abstract;
using ExamApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.BAL.Concrete
{
    public class LessonService : ILessonService
    {
        private readonly ILessonDal _lessonDal;

        public LessonService(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public async Task AddLesson(Lesson lesson)
        {
            await _lessonDal.Add(lesson);
        }

        public async Task DeleteLesson(Lesson lesson)
        {
          await _lessonDal.Delete(lesson);
        }

        public async Task<List<Lesson>> GetAll()
        {
           return await _lessonDal.GetAll();
        }

        public async Task<Lesson> GetByLessonCode(string lessonCode)
        {
            return await _lessonDal.Get(l => l.LessonCode==lessonCode);
        }

        public async Task UpdateLesson(Lesson lesson)
        {
           await _lessonDal.Update(lesson);
        }
    }
}
