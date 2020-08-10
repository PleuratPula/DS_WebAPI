using System;

namespace DS_WebAPI.Dtos
{
    public class ReadUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpireTime { get; set; }
        public int RoleId { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
