using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UdemyNewMicroservice.Catalog.API.Repositories;
using UdemyNewMicroservice.Shared;

namespace UdemyNewMicroservice.Catalog.API.Feautures.Categories.Create
{
    public class CreateCategoryCommandHandler(AppDbContext appDbContext)
        : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
    {
        public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existingCategory = await appDbContext.Categories
                .AnyAsync(c => c.Name == request.Name, cancellationToken);

            if (existingCategory)
            {
                ServiceResult<CreateCategoryResponse>.
                    Error("CategoryName already exists", $"The CategoryName '{request.Name}' already exist",
                    System.Net.HttpStatusCode.BadRequest);
            }
            var category = new Category
            {
                Name = request.Name,
                Id = NewId.NextSequentialGuid()
            };

            await appDbContext.AddAsync(category, cancellationToken);

            await appDbContext.SaveChangesAsync(cancellationToken);

            return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(
                new CreateCategoryResponse(category.Id), $"/categories/{category.Id}");
        }
    }
}

