using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemeTeShperndara.Models
{
    public class Professor
    {
        public int Id { get; set; }

        [Required]
        public string ProfessorName { get; set; }

        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}
