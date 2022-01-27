using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CategoryWithProductsDto:CategoryDto
    {
        //category'nin içinde bağlı olan productları aldık
        public List<ProductDto> products { get; set; }

    }
}
