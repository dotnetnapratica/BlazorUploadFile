using Microsoft.AspNetCore.Components.Forms;

namespace BlazorUpload.App.Services
{
    public class FileService
    {
        private readonly HttpClient httpClient;
        public FileService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient(nameof(FileService));
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            byte[] bytes;
            using(Stream stream = file.OpenReadStream())
            {
                using(MemoryStream memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    bytes = memoryStream.ToArray();
                }
            }

            var form = new MultipartFormDataContent();

            form.Add(new ByteArrayContent(bytes, 0, bytes.Length), "file", file.Name);

            try
            {
                var response = await httpClient.PostAsync("api/files", form);
                response.EnsureSuccessStatusCode();
                var filePath = await response.Content.ReadAsStringAsync();

                return $"Imagem salva em {filePath}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
