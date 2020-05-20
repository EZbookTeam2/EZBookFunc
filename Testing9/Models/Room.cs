using System;
using System.Collections.Generic;

namespace Testing9.Models
{
    public partial class Room
    {
        public Room()
        {
            Booking = new HashSet<Booking>();
            Slot = new HashSet<Slot>();
        }

        public string RoomId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Slot> Slot { get; set; }
    }
}
