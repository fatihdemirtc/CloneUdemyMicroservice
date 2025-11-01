#region

using UdemyNewMicroservice.Shared;

#endregion

namespace UdemyNewMicroservice.File.API.Features.File.Upload;

public record UploadFileCommand(IFormFile File) : IRequestByServiceResult<UploadFileCommandResponse>;