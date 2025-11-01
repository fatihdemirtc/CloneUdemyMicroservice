namespace UdemyNewMicroservice.File.API.Features.File;

public record UploadFileCommandResponse(string FileName, string FilePath, string OriginalFileName);