using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Testing9.Models
{
    public class EmailClass
    {
        public string to { get; set; }
        public string subject { get; set; }
        public string body { get; set; }

    }
}