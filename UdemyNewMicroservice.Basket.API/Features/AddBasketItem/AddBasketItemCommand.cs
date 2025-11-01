#region

using UdemyNewMicroservice.Shared;

#endregion

namespace UdemyNewMicroservice.Basket.API.Features.AddBasketItem;

public record AddBasketItemCommand(Guid CourseId, string CourseName, decimal CoursePrice, string? ImageUrl)
    : IRequestByServiceResult;