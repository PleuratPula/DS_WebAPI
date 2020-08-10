using System;
using SistemeTeShperndara.Models;

namespace DS_WebAPI.Dtos
{
    public class ReadStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Index { get; set; }
        public int DepartmentId { get; set; }
        public Status Status { get; set; }
    }
}
