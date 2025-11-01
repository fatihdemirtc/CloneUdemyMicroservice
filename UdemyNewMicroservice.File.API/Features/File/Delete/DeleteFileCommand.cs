#region

using UdemyNewMicroservice.Shared;

#endregion

namespace UdemyNewMicroservice.File.API.Features.File.Delete;

public record DeleteFileCommand(string FileName) : IRequestByServiceResult;