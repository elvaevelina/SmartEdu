using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.Backend.Services;

namespace SmartEdu.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            // Periksa apakah ada file yang dikirim
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "File tidak ditemukan." });
            }

            var uploadHandler = new UploadHandler();
            string result = uploadHandler.UploadFile(file);

            if (result.StartsWith("Error:"))
            {
                return BadRequest(new { message = result });
            }
            return Ok(new { fileName = result });
        }
    }
}
