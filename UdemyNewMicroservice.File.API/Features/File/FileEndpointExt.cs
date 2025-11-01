#region

using Asp.Versioning.Builder;
using UdemyNewMicroservice.Discount.API.Features.Discounts.CreateDiscount;
using UdemyNewMicroservice.File.API.Features.File.Delete;

#endregion

namespace UdemyNewMicroservice.File.API.Features.File;

public static class FileEndpointExt
{
    public static void AddFileGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("api/v{version:apiVersion}/files").WithTags("files").WithApiVersionSet(apiVersionSet)
            .UploadFileGroupItemEndpoint().DeleteFileGroupItemEndpoint()
            //.RequireAuthorization()
            ;
    }
}