namespace front_to_back.Helpers
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file, string webRootPath);
        void Delete(string fileName, string webRootPath);
    }
}
