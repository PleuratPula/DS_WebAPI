namespace DS_WebAPI.Dtos
{
    public class ReadSubjectDto
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string Semester { get; set; }
        public int DepartmentId { get; set; }
    }
}
