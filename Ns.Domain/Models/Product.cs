using Ns.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ns.Domain.Models
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }
    }
}
