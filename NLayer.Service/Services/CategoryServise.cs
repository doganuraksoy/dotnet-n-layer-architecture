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
    public class CategoryServise : Service<Category>, ICategoryService
    {
        //private readonly ICategoryService _categoryService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServise(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository = null, IMapper mapper = null) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoriId)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWithProductsAsync(categoriId);
            //bunu bir de dto ya dönüştürmemiz gerekiyor
            var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);
            return CustomResponseDto<CategoryWithProductsDto>.Success(200,categoryDto);
        }
    }
}
