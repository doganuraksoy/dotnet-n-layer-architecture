using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping
{
    //automapper kütüphanesini kullanacağız 
    //Bu kütüphane bir mapping kütüphanesidir. 
    //.net tarafından en çok kullanılan kütüphanelerdendir
    //entity'leri DTO'ya 
    //DTO'ları Entity'e otomatik mapleme işlemi gerçekleştirecek
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            //neyi neye maplemek istiyorsam burada yazarım.
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();//tersini almaya gerek olmadığı için reversemap koymadım.
            CreateMap<Product , ProductWithCategoryDto>();
            CreateMap<Category , CategoryWithProductsDto>();




        }
    }
}
