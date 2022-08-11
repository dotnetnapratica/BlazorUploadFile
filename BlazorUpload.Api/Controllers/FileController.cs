using BlazorUpload.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorUpload.Api.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FileController : ControllerBase
    {
        private readonly IStorageService storageService;
        public FileController(IStorageService storageService)
        {
            this.storageService = storageService;
        }

        [HttpPost]
        public async Task<string> UploadFile([FromForm] IFormFile file)
        {
            var fileSavedPath = await storageService.SaveFile(file);

            return fileSavedPath;
        }
    }
}