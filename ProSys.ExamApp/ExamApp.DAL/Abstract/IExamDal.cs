using ExamApp.DAL.Concrete.EntityFramework;
using ExamApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.DAL.Abstract
{
    public interface IExamDal:IEntityRepository<Exam>
    {
    }
}
