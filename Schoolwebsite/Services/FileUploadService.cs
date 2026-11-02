namespace Schoolwebsite.Services
{

    public interface IFileUploadService
    {
        /// <summary>
        /// Saves an uploaded image under wwwroot/images/{folder}/ with a generated
        /// unique filename, and returns the web-relative path to store on the entity
        /// (e.g. "/images/teachers/3f1a...-photo.jpg").
        /// </summary>
        Task<string> SaveImageAsync(IFormFile file, string folder);

        /// <summary>
        /// Deletes a previously-saved image given the relative path stored on an
        /// entity. Safe to call with paths that don't exist on disk (e.g. seeded
        /// placeholder images) — it just does nothing in that case.
        /// </summary>
        void DeleteImage(string relativePath);
    }


    public class FileUploadService: IFileUploadService
    {

        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".webp", ".gif" };
        private const long MaxFileSizeBytes = 5 * 1024 * 1024; // 5 MB

        private readonly IWebHostEnvironment _env;

        public FileUploadService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SaveImageAsync(IFormFile file, string folder)
        {
            if (file.Length == 0)
            {
                throw new ArgumentException("The uploaded file is empty.");
            }

            if (file.Length > MaxFileSizeBytes)
            {
                throw new ArgumentException("The uploaded image must be 5 MB or smaller.");
            }

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(extension))
            {
                throw new ArgumentException("Only JPG, PNG, GIF and WEBP images are allowed.");
            }

            var fileName = $"{Guid.NewGuid()}{extension}";
            var folderPath = Path.Combine(_env.WebRootPath, "images", folder);
            Directory.CreateDirectory(folderPath);

            var fullPath = Path.Combine(folderPath, fileName);
            await using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/images/{folder}/{fileName}";
        }

        public void DeleteImage(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
            {
                return;
            }

            var fullPath = Path.Combine(_env.WebRootPath, relativePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }


    }
}
