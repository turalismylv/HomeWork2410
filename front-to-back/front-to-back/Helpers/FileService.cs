namespace front_to_back.Helpers
{
    public class FileService :IFileService
    {

        public async Task<string> UploadAsync(IFormFile file,string webRootPath)
        {
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var path = Path.Combine(webRootPath, "assets/img", fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }

        public void Delete( string fileName,string webRootPath)
        {
            var path = Path.Combine(webRootPath, "assets/img", fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
