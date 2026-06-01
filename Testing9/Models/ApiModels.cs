using System.Collections.Generic;

namespace Testing9.Models
{
    public class ApiMessage
    {
        public string Message { get; set; }
    }

    public class BookingApplicationItem
    {
        public string BookingId { get; set; }
        public string RoomName { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Username { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public List<string> BookingApplication { get; set; }
    }

    public class CancellationQueueItem
    {
        public int CancelId { get; set; }
        public string BookingId { get; set; }
        public string RoomName { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Username { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public List<string> CancellationList { get; set; }
    }

    public class AdminBookingItem
    {
        public string BookingId { get; set; }
        public string UsersId { get; set; }
        public string RoomId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string Username { get; set; }
        public List<string> BookingList { get; set; }
    }

    public class RoomSummary
    {
        public string RoomId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
    }

    public class ScheduleItem
    {
        public string BookingId { get; set; }
        public string UsersId { get; set; }
        public string RoomId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string Username { get; set; }
        public string Roompic { get; set; }
        public List<string> BookingList { get; set; }
    }

    public class UserSummary
    {
        public string UsersId { get; set; }
        public string Names { get; set; }
        public string Passwords { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string StartDate { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public string Code { get; set; }
        public string Profilepic { get; set; }
    }
}
