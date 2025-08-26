using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ProductDTO.Request
{
    public class IsInStockRequest
     {
        public string? ProductName { get; set; }

       
        public Guid? ProductId { get; set; }
    }
}
