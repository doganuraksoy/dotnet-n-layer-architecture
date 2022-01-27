using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class ProductWithCategoryDto:ProductDto
    {
        //burada category'i aldım 
        public CategoryDto Category { get; set; }

    }
}
