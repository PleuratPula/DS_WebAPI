using System.Collections.Generic;

namespace SistemeTeShperndara.Models
{
    public class Role
    {
        public int Id { get; set; }
        public RoleName RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }

    public enum RoleName
    {
        Admin,
        View
    }
}
