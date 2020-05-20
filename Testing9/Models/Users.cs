using System;
using System.Collections.Generic;

namespace Testing9.Models
{
    public partial class Users
    {
        public Users()
        {
            Booking = new HashSet<Booking>();
        }

        public string UsersId { get; set; }
        public string Names { get; set; }
        public string Passwords { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string StartDate { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public string Code { get; set; }
        public byte[] Profilepic { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
