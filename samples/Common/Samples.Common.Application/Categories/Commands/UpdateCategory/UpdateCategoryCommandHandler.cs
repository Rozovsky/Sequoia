using AutoMapper;
using MediatR;
using Samples.Common.Application.Categories.ViewModels;
using Samples.Common.Application.Interfaces;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryVm>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            ICategoryService categoryService,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<CategoryVm> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryAsync(request.Id, cancellationToken);
            _mapper.Map(request.Dto, category);
            category = await _categoryRepository.UpdateCategoryAsync(request.Id, category, cancellationToken);

            return _mapper.Map<CategoryVm>(category);
        }
    }
}
