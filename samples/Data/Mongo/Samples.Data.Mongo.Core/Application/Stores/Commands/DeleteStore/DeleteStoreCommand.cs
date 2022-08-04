using MediatR;

namespace Samples.Data.Mongo.Core.Application.Stores.Commands.DeleteStore
{
    public class DeleteStoreCommand : IRequest
    {
        public string Id { get; set; }
    }
}
