using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemeTeShperndara.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public string Comment { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
