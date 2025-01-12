using AutoMapper;
using BookEcommerceWeb.Models.DTOs;
using BookEcommerceWeb.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEcommerceWeb.Services.MappingProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.DisplayOrder, opt => opt.MapFrom(src => src.DisplayOrder))
            .ReverseMap();

            CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))                  
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))            
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))          
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))            
            .ForMember(dest => dest.Price50, opt => opt.MapFrom(src => src.Price50))        
            .ForMember(dest => dest.Price100, opt => opt.MapFrom(src => src.Price100))      
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))  
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ReverseMap(); ;     
        }
    }
}
