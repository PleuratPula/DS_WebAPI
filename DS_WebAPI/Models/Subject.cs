using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemeTeShperndara.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        public string SubjectName { get; set; }

        [Required]
        public string Semester { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Professor> Professors { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
