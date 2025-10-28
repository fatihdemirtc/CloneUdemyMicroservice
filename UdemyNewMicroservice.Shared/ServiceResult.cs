using Refit;
using System;
using System.Net;
using System.Text.Json.Serialization;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace UdemyNewMicroservice.Shared
{
    public class ServiceResult
    {
        [JsonIgnore] public HttpStatusCode Status { get; set; }
        public ProblemDetails? Fail { get; set; }

        [JsonIgnore] public bool IsSuccess => Fail is null;
        [JsonIgnore] public bool IsFail => !IsSuccess;

        public static ServiceResult SuccessAsNoContent()
        {
            return new ServiceResult { Status = HttpStatusCode.NoContent };
        }

        public static ServiceResult ErrorAsNotFound()
        {
            return new ServiceResult
            {
                Status = HttpStatusCode.NotFound,
                Fail = new ProblemDetails
                {
                    Title = "Not Found",
                    Detail = "The requested resource was not found."
                }
            };
        }

        public static ServiceResult ErrorFromProblemDetails(ApiException exception)
        {
            if (string.IsNullOrEmpty(exception.Content))
            {
                return new ServiceResult
                {
                    Status = exception.StatusCode,
                    Fail = new ProblemDetails()
                    {
                        Title = exception.Message,
                    }
                };
            }

            var problemDetails = System.Text.Json.JsonSerializer.Deserialize<ProblemDetails>(exception.Content,
                new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return new ServiceResult
            {
                Status = exception.StatusCode,
                Fail = problemDetails
            };
        }

        public static ServiceResult Error(ProblemDetails problemDetails, HttpStatusCode statusCode)
        {
            return new ServiceResult
            {
                Status = statusCode,
                Fail = problemDetails
            };
        }

        public static ServiceResult Error(string title, string description, HttpStatusCode statusCode)
        {
            return new ServiceResult
            {
                Status = statusCode,
                Fail = new ProblemDetails()
                {
                    Title = title,
                    Detail = description,
                    Status = (int)statusCode
                }
            };
        }

        public static ServiceResult Error(string title, HttpStatusCode statusCode)
        {
            return new ServiceResult
            {
                Status = statusCode,
                Fail = new ProblemDetails()
                {
                    Title = title,
                    Status = (int)statusCode
                }
            };
        }

        public static ServiceResult ErrorFromValidation(IDictionary<string, object?> errors)
        {
            return new ServiceResult
            {
                Status = HttpStatusCode.BadRequest,
                Fail = new ProblemDetails()
                {
                    Title = "Validation errors occured",
                    Detail = "Please check the errors property",
                    Extensions = errors,
                    Status = HttpStatusCode.BadRequest.GetHashCode()
                }
            };
        }
    }
    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }
        public string? UrlAsCreated { get; set; }

        //200
        public static ServiceResult<T> SuccessAsOk(T data)
        {
            return new ServiceResult<T>
            {
                Status = HttpStatusCode.OK,
                Data = data
            };
        }

        //201
        public static ServiceResult<T> SuccessAsCreated(T data, string url)
        {
            return new ServiceResult<T>
            {
                Status = HttpStatusCode.OK,
                Data = data,
                UrlAsCreated = url
            };
        }

        public new static ServiceResult<T> ErrorFromProblemDetails(ApiException exception)
        {
            if (string.IsNullOrEmpty(exception.Content))
            {
                return new ServiceResult<T>
                {
                    Status = exception.StatusCode,
                    Fail = new ProblemDetails()
                    {
                        Title = exception.Message,
                    }
                };
            }

            var problemDetails = System.Text.Json.JsonSerializer.Deserialize<ProblemDetails>(exception.Content,
                new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return new ServiceResult<T>
            {
                Status = exception.StatusCode,
                Fail = problemDetails
            };
        }

        public new static ServiceResult<T> Error(ProblemDetails problemDetails, HttpStatusCode statusCode)
        {
            return new ServiceResult<T>
            {
                Status = statusCode,
                Fail = problemDetails
            };
        }

        public new static ServiceResult<T> Error(string title, string description, HttpStatusCode statusCode)
        {
            return new ServiceResult<T>
            {
                Status = statusCode,
                Fail = new ProblemDetails()
                {
                    Title = title,
                    Detail = description,
                    Status = (int)statusCode
                }
            };
        }

        public new static ServiceResult<T> Error(string title, HttpStatusCode statusCode)
        {
            return new ServiceResult<T>
            {
                Status = statusCode,
                Fail = new ProblemDetails()
                {
                    Title = title,
                    Status = (int)statusCode
                }
            };
        }

        public new static ServiceResult<T> ErrorFromValidation(IDictionary<string,object?> errors)
        {
            return new ServiceResult<T>
            {
                Status = HttpStatusCode.BadRequest,
                Fail = new ProblemDetails()
                {
                    Title = "Validation errors occured",
                    Detail = "Please check the errors property",
                    Extensions=errors,
                    Status = HttpStatusCode.BadRequest.GetHashCode()
                }
            };
        }
    }

}
