﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemeTeShperndara.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Index { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
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
