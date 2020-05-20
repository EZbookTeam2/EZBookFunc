using System;
using System.Collections.Generic;

namespace Testing9.Models
{
    public partial class Cancellation
    {
        public string CancellationId { get; set; }
        public string BookingId { get; set; }
        public string Status { get; set; }
    }
}
