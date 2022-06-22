using ExamApp.DAL.Abstract;
using ExamApp.DAL.Concrete.EntityFramework.Contexts;
using ExamApp.DAL.Concrete.EntityFramework.Repositorires;
using ExamApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.DAL.Concrete.EntityFramework
{
    public class EfStudentDal: EfEntityRepositoryBase<Student, ExamDbContext>, IStudentDal
    {
    }
}
