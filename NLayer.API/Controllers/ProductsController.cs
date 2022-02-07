using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        //mapleme işlemini burada gerçekleştireceğim 

        private readonly IMapper _mapper;
        //controllerlar sadece servisleri bilir bu yüzden servisi de alalım

        private readonly IProductService _Service;

        public ProductsController(IService<Product> service, IMapper mapper, IProductService productService = null)
        {
            
            _mapper = mapper;
            _Service = productService;
        }

        /// GET api/products/GetProductsWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _Service.GetProductWithCategory());

        }





        /// GET api/products
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _Service.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        //GET api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var product = await _Service.GetByIdAsync(id);
            //entity olduğu için dto dönmem gerekli 
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _Service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _Service.UpdateAsync(_mapper.Map<Product>(productDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }



        //  DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product =await _Service.GetByIdAsync(id);
            await _Service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
