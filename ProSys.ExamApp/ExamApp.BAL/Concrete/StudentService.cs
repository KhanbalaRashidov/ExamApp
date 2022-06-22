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
    public class StudentService : IStudentService
    {
        private readonly IStudentDal _studentDal;

        public StudentService(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public async Task AddStudent(Student student)
        {
            await _studentDal.Add(student);
        }

        public async Task DeleteStudent(Student student)
        {
            await _studentDal.Delete(student);
        }

        public async Task<List<Student>> GetAll()
        {
            return await _studentDal.GetAll();
        }

        public Task<Student> GetByNumber(int? number)
        {
            return _studentDal.Get(n => n.StudentNumber == number);
        }

        public async Task UpdateStudent(Student student)
        {
          await _studentDal.Update(student);
        }
    }
}
