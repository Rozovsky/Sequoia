using MediatR;
using Samples.Client.Http.Core.Application.Common.Dto;
using Samples.Client.Http.Core.Application.Common.ViewModels;

namespace Samples.Client.Http.Core.Application.Todos.Commands.PatchCompleted
{
    public class PatchCompletedCommand : IRequest<TodoVm>
    {
        public long Id { get; set; }
        public TodoCompletedToPatchDto Dto { get; set; }
    }
}
