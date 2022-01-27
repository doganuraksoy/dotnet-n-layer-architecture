using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
   
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //api/categories/GetSingleCategoryByIdWithProductsAsync/2
        [HttpGet("[action]/{categoriyId}")]
        public async Task<IActionResult>GetSingleCategoryByIdWithProducts(int categoriyId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWithProductsAsync(categoriyId));
        }
    }
}
