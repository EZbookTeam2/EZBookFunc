using System;
using System.Collections.Generic;

namespace EZBook.Api.Models
{
    public partial class Testing
    {
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Username { get; set; }
    }
}
