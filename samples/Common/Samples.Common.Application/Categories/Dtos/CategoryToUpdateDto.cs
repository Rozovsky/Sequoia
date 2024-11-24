using AutoMapper;
using Samples.Common.Domain.Entities;

namespace Samples.Common.Application.Categories.Dtos;

[AutoMap(typeof(Category), ReverseMap = true)]
public class CategoryToUpdateDto
{
    public string Name { get; set; }
}