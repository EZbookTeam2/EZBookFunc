﻿using System;
using System.Collections.Generic;

namespace Testing9.Models
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
