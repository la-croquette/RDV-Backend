using System;
namespace RDV_Backend.Model
{
	public class Notification
	{
        public int NotificationId { get; set; }
        public int? User_Id { get; set; }
        public string? Message { get; set; }
    }
}

