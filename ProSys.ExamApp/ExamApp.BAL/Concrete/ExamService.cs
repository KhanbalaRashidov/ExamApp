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
    public class ExamService:IExamService
    {
        private readonly IExamDal _examDal;

        public ExamService(IExamDal examDal)
        {
            _examDal = examDal;
        }

        public async Task AddExam(Exam exam)
        {
            await _examDal.Add(exam);
        }

        public async Task DeleteExam(Exam exam)
        {
            await _examDal.Delete(exam);
        }

        public async Task<List<Exam>> GetAll()
        {
           return await _examDal.GetAll();
        }

        public async Task<Exam> GetById(int? id)
        {
            return await _examDal.Get(e => e.Id == id);
        }

        public async Task UpdateExam(Exam exam)
        {
            await _examDal.Update(exam);
        }
    }
}
