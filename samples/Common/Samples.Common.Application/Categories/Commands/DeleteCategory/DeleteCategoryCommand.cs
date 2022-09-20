using MediatR;

namespace Samples.Common.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public string Id { get; set; }
    }
}
