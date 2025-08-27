using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ProductDTO.Response
{
    public class IsInStockResponse
    {
        public bool success;

        public Guid? ProductId { get; set; }
        public string? Name { get; set; }
        public int? StockQuantity { get; set; }
        public string? Message { get; set; }
    }
}
