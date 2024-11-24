using MediatR;
using Samples.Common.Application.Ingredients.ViewModels;
using Sequoia.Data.Models;

namespace Samples.Common.Application.Ingredients.Queries.GetIngredientsPaged;

public class GetIngredientsPagedQuery : IRequest<Paged<IngredientVm>>
{
    public int Page { get; set; }
    public int Limit { get; set; }
}