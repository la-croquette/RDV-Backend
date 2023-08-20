using System;
namespace RDV_Backend.Model
{
	public class User
	{
        public int User_id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}

