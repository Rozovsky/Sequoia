﻿using AutoMapper;
using MediatR;
using Samples.Data.Mongo.Core.Application.CoffeeMachines.ViewModels;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Domain.Entities;
using Sequoia.Exceptions;

namespace Samples.Data.Mongo.Core.Application.CoffeeMachines.Commands.UpdateCoffeeMachine
{
    public class UpdateCoffeeMachineCommandHandler : IRequestHandler<UpdateCoffeeMachineCommand, CoffeeMachineVm>
    {
        private readonly ICoffeeMachineService _coffeeMachineService;
        private readonly IMapper _mapper;
        private readonly IStoreService _storeService;

        public UpdateCoffeeMachineCommandHandler(
            ICoffeeMachineService coffeeMachineService,
            IMapper mapper,
            IStoreService storeService)
        {
            _coffeeMachineService = coffeeMachineService;
            _mapper = mapper;
            _storeService = storeService;
        }

        public async Task<CoffeeMachineVm> Handle(UpdateCoffeeMachineCommand request, CancellationToken cancellationToken)
        {
            // check store exist
            var store = await _storeService.GetStore(request.Dto.StoreId, cancellationToken);
            if (store == null)
                throw new NotFoundException(nameof(Store), request.Dto.StoreId);

            var machine = await _coffeeMachineService.UpdateCoffeeMachine(request.Id, request.Dto, cancellationToken);

            return _mapper.Map<CoffeeMachineVm>(machine);
        }
    }
}