using System.Collections.Generic;

namespace SistemeTeShperndara.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string ProfessorName { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}
