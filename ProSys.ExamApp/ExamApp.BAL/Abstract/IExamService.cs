using ExamApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.BAL.Abstract
{
    public interface IExamService
    {
        Task<List<Exam>> GetAll();
        Task<Exam> GetById(int? id);
        Task AddExam(Exam exam);
        Task UpdateExam(Exam exam);
        Task DeleteExam(Exam exam);
    }
}
