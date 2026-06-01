using Testing9.Models;

namespace Testing9.Infrastructure
{
    public static class BookingFactory
    {
        public static Booking CreateNewBooking(Booking source)
        {
            return new Booking
            {
                BookingId = source.BookingId,
                UsersId = source.UsersId,
                RoomId = source.RoomId,
                Name = source.Name,
                Title = source.Title,
                Location = source.Location,
                Date = source.Date,
                Time = source.Time,
                Status = BookingStatusValues.PendingApproval,
                StartTime = source.StartTime,
                EndTime = source.EndTime
            };
        }
    }
}
