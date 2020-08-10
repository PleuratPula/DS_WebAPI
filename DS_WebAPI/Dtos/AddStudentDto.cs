using System;
using System.ComponentModel.DataAnnotations;
using SistemeTeShperndara.Models;

namespace DS_WebAPI.Dtos
{
    public class AddStudentDto
    {
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

        [Required]
        public Status Status { get; set; }
    }
}
