using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace SmartEdu.Backend.Services
{
    public class UploadHandler
    {
        public string UploadFile(IFormFile file)
        {
            try
            {
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                var validExtensions = new List<string> { ".jpg", ".jpeg", ".png"};
                if (!validExtensions.Contains(extension))
                {
                    throw new InvalidDataException("Unsupported file type.");
                }
                long size = file.Length;
                long maxAllowedSize = 10 * 1024 * 1024; // 10MB
                if (maxAllowedSize < size)
                {
                    throw new InvalidDataException("File size exceeds the limit of 10MB.");
                }
                string filename = Guid.NewGuid().ToString() + extension;
                string projectPath = Directory.GetCurrentDirectory();
                string uploadPath = Path.Combine(projectPath, "Uploads");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                string filePath = Path.Combine(uploadPath, filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return filename;
            }
            catch (Exception ex)
            {
                throw new Exception("File upload failed: " + ex.Message);
            }
        }
    }
}
