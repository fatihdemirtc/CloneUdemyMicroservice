using AutoMapper;
using UdemyNewMicroservice.Catalog.API.Feautures.Categories.Dtos;

namespace UdemyNewMicroservice.Catalog.API.Feautures.Categories
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
