using System.Collections.Generic;

namespace SistemeTeShperndara.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string Semester { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Professor> Professors { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
