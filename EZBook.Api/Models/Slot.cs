using System;
using System.Collections.Generic;

namespace EZBook.Api.Models
{
    public partial class Slot
    {
        public string SlotId { get; set; }
        public string RoomId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }

        public virtual Room Room { get; set; }
    }
}
