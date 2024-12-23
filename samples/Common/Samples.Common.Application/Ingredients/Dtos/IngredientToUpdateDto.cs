﻿using AutoMapper;
using Samples.Common.Domain.Entities;

namespace Samples.Common.Application.Ingredients.Dtos;

[AutoMap(typeof(Ingredient), ReverseMap = true)]
public class IngredientToUpdateDto
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
}