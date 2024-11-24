using AutoMapper;
using Samples.Common.Domain.Entities;

namespace Samples.Common.Application.Categories.Dtos;

[AutoMap(typeof(Category), ReverseMap = true)]
public class CategoryToCreateDto
{
    public string Name { get; set; }
}