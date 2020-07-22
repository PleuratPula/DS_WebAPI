using System;
using System.Collections.Generic;

namespace SistemeTeShperndara.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Index { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public Status Status { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }

    public enum Status
    {
        Aktiv,
        Diplomuar,
        Regjistrurar,
        Suspenduar
    }
}
