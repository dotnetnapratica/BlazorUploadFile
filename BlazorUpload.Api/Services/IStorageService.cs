namespace BlazorUpload.Api.Services
{
    public interface IStorageService
    {
        Task<string> SaveFile(IFormFile file);
    }
}
