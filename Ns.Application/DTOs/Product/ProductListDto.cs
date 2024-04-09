using System;

namespace Ns.Application.DTOs.Product
{
    public class ProductListDto
    {
        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public bool IsAvailable { get; set; }
    }
}
