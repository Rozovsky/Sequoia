using AutoMapper;
using Samples.Common.Application.Categories.Dtos;
using Samples.Common.Application.Categories.ViewModels;
using Samples.Common.Domain.Entities;

namespace Samples.Common.Application.Common.Mappings
{
    // TODO: is needed? [AutoMap(typeof(Model), ReverseMap = true)]
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryVm>();
            CreateMap<CategoryToCreateDto, Category>();
            CreateMap<CategoryToUpdateDto, Category>();
        }
    }
}
