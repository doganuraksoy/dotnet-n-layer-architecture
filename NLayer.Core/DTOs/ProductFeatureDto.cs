using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class ProductFeatureDto
    {
        public int Id { get; set; }
        public String Color { get; set; }
        public int Height { get; set; }
        public int width { get; set; }
        public int ProductId { get; set; }
    }
}
