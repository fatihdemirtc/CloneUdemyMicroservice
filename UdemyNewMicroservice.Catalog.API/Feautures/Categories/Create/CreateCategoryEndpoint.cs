using MediatR;
using UdemyNewMicroservice.Shared;
using UdemyNewMicroservice.Shared.Extensions;
using UdemyNewMicroservice.Shared.Filters;

namespace UdemyNewMicroservice.Catalog.API.Feautures.Categories.Create
{
    public static class CreateCategoryEndpoint
    {
        public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapPost("/", async (IMediator mediator, CreateCategoryCommand command) => 
                (await mediator.Send(command)).ToGenericResult()).AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();           

            return groupBuilder;
        }
    }
}
