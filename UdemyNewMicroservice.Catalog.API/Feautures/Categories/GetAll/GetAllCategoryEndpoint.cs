using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UdemyNewMicroservice.Catalog.API.Feautures.Categories.Dtos;
using UdemyNewMicroservice.Catalog.API.Repositories;
using UdemyNewMicroservice.Shared;
using UdemyNewMicroservice.Shared.Extensions;

namespace UdemyNewMicroservice.Catalog.API.Feautures.Categories.GetAll
{
    public class GetAllCategoryQuery : IRequest<ServiceResult<List<CategoryDto>>>;

    public class GetAllCategoryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDto>>>
    {
        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories.ToListAsync(cancellationToken: cancellationToken);
            var categoriesasDto = mapper.Map<List<CategoryDto>>(categories);
            return ServiceResult<List<CategoryDto>>.SuccessAsOk(categoriesasDto);
        }
    }

    public static class GetAllCategoryEndpoint
    {
        public static RouteGroupBuilder GetAllCategoryGroupItemEndpoint(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapGet("/", async (IMediator mediator) =>
                (await mediator.Send(new GetAllCategoryQuery())).ToGenericResult());

            return groupBuilder;
        }
    }
}
