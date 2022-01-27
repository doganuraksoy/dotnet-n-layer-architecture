using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>,IProductService
    {
        private readonly IProductRepository _productrepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper = null, IProductRepository productrepository = null) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productrepository = productrepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductWithCategory()
        {
            //ÖNCE datayı alıyorum 
            var Product = await _productrepository.GetProductWithCategory();
            var productsDto=_mapper.Map<List<ProductWithCategoryDto>>(Product);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }
    }
}
