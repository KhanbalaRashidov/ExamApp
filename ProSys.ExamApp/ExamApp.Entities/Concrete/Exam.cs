using ExamApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Entities.Concrete
{
    public class Exam : IEntity
    {
        public int Id { get; set; }
        [Column(TypeName = "char(3)")]
        [ForeignKey("Lesson")]
        public string LessonCode { get; set; }
        public Lesson Lesson { get; set; }

        [Column(TypeName = "numeric(5,0)")]
        [ForeignKey("Student")]
        public int StudentNumber { get; set; }
        public Student Student { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExamDate { get; set; }

        [Column(TypeName = "numeric(1,0)")]
        public int Score { get; set; }
    }
}










