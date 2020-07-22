using System;

namespace SistemeTeShperndara.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpireTime { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
