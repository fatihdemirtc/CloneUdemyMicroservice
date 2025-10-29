using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace UdemyNewMicroservice.Shared.Filters
{
    public class ValidationFilter<T> : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();

            if (validator == null)
            {
                return await next(context);
            }

            var firstArg = context.Arguments.OfType<T>().FirstOrDefault();

            if(firstArg == null)
            {
                return await next(context);
            }

            var validationResult = await validator.ValidateAsync(firstArg);

            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            return await next(context);
        }
    }
}
