using AutoMapper;
using MediatR;
using UdemyNewMicroservice.Catalog.API.Feautures.Categories.Dtos;
using UdemyNewMicroservice.Catalog.API.Feautures.Categories.GetAll;
using UdemyNewMicroservice.Catalog.API.Repositories;
using UdemyNewMicroservice.Shared;
using UdemyNewMicroservice.Shared.Extensions;

namespace UdemyNewMicroservice.Catalog.API.Feautures.Categories.GetById
{
    public record GetCategoryByIdQuery(Guid id) : IRequest<ServiceResult<CategoryDto>>;


    public class GetCategoryByIdQueryHandler(AppDbContext context, IMapper mapper)
        : IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDto>>
    {
        public async Task<ServiceResult<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await context.Categories.FindAsync(request.id, cancellationToken);
            if (category == null)
            {
                return ServiceResult<CategoryDto>.Error("Category not found", $"The category with in id({request.id}) was not found", System.Net.HttpStatusCode.NotFound);
            }
            var categoryAsDto = mapper.Map<CategoryDto>(category);
            return ServiceResult<CategoryDto>.SuccessAsOk(categoryAsDto);
        }
    }

    public static class GetCategoryByIdEndpoint
    {
        public static RouteGroupBuilder GetByIdCategoryGroupItemEndpoint(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapGet("/{id:guid}", async (IMediator mediator, Guid id) =>
                (await mediator.Send(new GetCategoryByIdQuery(id))).ToGenericResult());

            return groupBuilder;
        }
    }
}
