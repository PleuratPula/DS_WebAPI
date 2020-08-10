namespace DS_WebAPI.Dtos
{
    public class ReadExamDto
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public int ProfessorId { get; set; }

        public int Points { get; set; }

        public int Grade { get; set; }
    }
}
