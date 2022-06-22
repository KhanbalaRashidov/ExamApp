using ExamApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.BAL.Abstract
{
    public interface IStudentService
    {
        Task<List<Student>> GetAll();
        Task<Student> GetByNumber(int? number);
        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(Student student);
    }
}
