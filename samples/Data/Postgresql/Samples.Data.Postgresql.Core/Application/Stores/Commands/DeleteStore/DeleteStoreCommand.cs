using MediatR;

namespace Samples.Data.Postgresql.Core.Application.Stores.Commands.DeleteStore
{
    public class DeleteStoreCommand : IRequest
    {
        public long Id { get; set; }
    }
}
