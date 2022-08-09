using MediatR;

namespace Samples.Data.WebClient.Core.Application.Stores.Commands.DeleteStore
{
    public class DeleteStoreCommand : IRequest
    {
        public long Id { get; set; }
    }
}
