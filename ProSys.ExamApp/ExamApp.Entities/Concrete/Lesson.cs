using ExamApp.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Entities.Concrete
{

    public class Lesson : IEntity
    {
        [Key]
        [Column(TypeName = "char(3)")]
        public string LessonCode { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string LessonName { get; set; }

        [Column(TypeName = "numeric(2,0)")]
        public int Class { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string TeacherName { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string TeacherSurname { get; set; }

        public virtual IEnumerable<Exam> Exams { get; set; }
    }
}






