namespace BlazorUpload.Api.Services
{
    public class LocalStorageService : IStorageService
    {
        public async Task<string> SaveFile(IFormFile file)
        {
            var tempPath = Path.GetTempPath();

            var fileToSavePath = Path.Combine(tempPath, file.FileName);
            using(var fileStream = System.IO.File.Create(fileToSavePath))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileToSavePath;
        }
    }
}
