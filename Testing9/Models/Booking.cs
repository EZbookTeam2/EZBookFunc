using System;
using System.Collections.Generic;

namespace Testing9.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Cancellation = new HashSet<Cancellation>();
        }

        public string BookingId { get; set; }
        public string UsersId { get; set; }
        public string RoomId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public virtual Room Room { get; set; }
        public virtual Users Users { get; set; }
        public virtual ICollection<Cancellation> Cancellation { get; set; }
    }
}
