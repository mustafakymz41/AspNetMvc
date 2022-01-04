using Microsoft.OData.Edm;
using System;

namespace KisiGirisCikisKontrol.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long TcNo { get; set; }
        public string HesKod { get; set; }
        public string loginTime { get; set; }
        public string ExitTime { get; set; }
    }
}
