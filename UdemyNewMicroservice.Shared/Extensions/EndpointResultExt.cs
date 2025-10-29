using Microsoft.AspNetCore.Http;
using System.Net;

namespace UdemyNewMicroservice.Shared.Extensions
{
    public static class EndpointResultExt
    {
        public static IResult ToGenericResult<T>(this ServiceResult<T> serviceResult)
        {
            return serviceResult.Status switch
            {
                HttpStatusCode.OK => Results.Ok(serviceResult.Data),
                HttpStatusCode.Created => Results.Created(serviceResult.UrlAsCreated, serviceResult.Data),
                HttpStatusCode.NotFound => Results.NotFound(serviceResult.Fail),
                _ => Results.Problem(serviceResult.Fail!)
            };
        }

        public static IResult ToEndpointResult(this ServiceResult serviceResult)
        {
            return serviceResult.Status switch
            {
                HttpStatusCode.NoContent => Results.NoContent(),
                HttpStatusCode.NotFound => Results.NotFound(serviceResult.Fail),
                _ => Results.Problem(serviceResult.Fail!)
            };
        }
    }
}
