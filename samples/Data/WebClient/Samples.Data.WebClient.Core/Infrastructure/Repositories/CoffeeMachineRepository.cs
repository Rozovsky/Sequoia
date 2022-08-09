using Samples.Data.WebClient.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.WebClient.Core.Application.Common.Interfaces;
using Samples.Data.WebClient.Core.Domain.Models.CoffeeMachines;
using Sequoia.Data.WebClient.Enums;
using Sequoia.Data.WebClient.Extensions;
using Sequoia.Data.WebClient.Interfaces;

namespace Samples.Data.WebClient.Core.Infrastructure.Repositories
{
    public class CoffeeMachineRepository : ICoffeeMachineRepository
    {
        private readonly IWebClient _webClient;

        public CoffeeMachineRepository(IWebClient webClient)
        {
            _webClient = webClient;
            _webClient.Configure(c =>
            {
                c.WebResourcePath = "data-mongo-api/machines-service";
                c.ErrorHandlingMode = ErrorHandlingMode.Debug;
                c.IgnoreSslErrors = true;
                c.AuthenticationType = AuthenticationType.Basic;
            });
        }

        public async Task<CoffeeMachine> CreateCoffeeMachine(CoffeeMachineToCreateDto dto, CancellationToken cancellationToken)
        {
            var machine = await _webClient
                .WithStringContent(dto)
                .Post<CoffeeMachine>("/coffee-machines", cancellationToken);

            return machine;
        }

        public async Task<CoffeeMachine> UpdateCoffeeMachine(long id, CoffeeMachineToUpdateDto dto, CancellationToken cancellationToken)
        {
            var machine = await _webClient
                .WithStringContent(dto)
                .Put<CoffeeMachine>($"/coffee-machines/{id}", cancellationToken);

            return machine;
        }

        public async Task DeleteCoffeeMachine(long id, CancellationToken cancellationToken)
        {
            await _webClient.Delete($"/coffee-machines/{id}", cancellationToken);
        }

        public async Task<CoffeeMachine> GetCoffeeMachine(long id, CancellationToken cancellationToken)
        {
            var machine = await _webClient
               .Get<CoffeeMachine>($"/coffee-machines/{id}", cancellationToken);

            return machine;
        }

        public async Task<List<CoffeeMachine>> GetCoffeeMachines(CancellationToken cancellationToken)
        {
            var machines = await _webClient
                .Get<List<CoffeeMachine>>("/coffee-machines", cancellationToken);

            return machines;
        }

        // TODO: add paged
    }
}
