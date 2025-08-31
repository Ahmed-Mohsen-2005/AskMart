using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ProductDTO.Request
{
    public class RemoveProductRequest
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
    }
}
