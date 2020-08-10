using System.ComponentModel.DataAnnotations;

namespace DS_WebAPI.Dtos
{
    public class AddExamDto
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int ProfessorId { get; set; }

        [Required]
        public int Points { get; set; }

        [Required]
        public int Grade { get; set; }
    }
}
