using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAngular2POC.Models
{
    public class Hotel
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public bool AllowsPets { get; set; }
        public bool HasFreeWiFi { get; set; }
        public bool HasFreeBreakfast { get; set; }

        [MaxLength(100)]
        public string StreetAddress { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [MaxLength(10)]
        public string ZipCode { get; set; }
    }
}
