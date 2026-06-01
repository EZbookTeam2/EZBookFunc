using System;
using System.Collections.Generic;

namespace EZBook.Api.Models
{
    public partial class Cancellation
    {
        public int CancellationId { get; set; }
        public string BookingId { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
