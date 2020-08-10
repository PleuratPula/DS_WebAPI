using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemeTeShperndara.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        public RoleName RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }

    public enum RoleName
    {
        Admin,
        View
    }
}
