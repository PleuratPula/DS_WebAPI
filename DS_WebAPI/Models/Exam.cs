namespace SistemeTeShperndara.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int? ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }
        public int Points { get; set; }
        public int Grade { get; set; }
    }
}
