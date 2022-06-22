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
    public class Student : IEntity
    {
        [Key]
        [Column(TypeName = "numeric(5,0)")]
        public int StudentNumber { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Surname { get; set; }

        [Column(TypeName = "numeric(2,0)")]
        public int Class { get; set; }

        public virtual IEnumerable<Exam> Exams { get; set; }
    }
}






