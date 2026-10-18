using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BVK_Advocates_Law_Firm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFilesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var files = new List<string>();
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
            if (Directory.Exists(folderPath))
            {
                // Gets all files from the top folder. 
                // To include subfolders, use SearchOption.AllDirectories
                var filePaths = Directory.EnumerateFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);

                foreach (string filePath in filePaths)
                {
                    files.Add(filePath);
                }
            }
            return Ok(files);
        }


        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file selected for upload.");
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", file.FileName);
            // Ensure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok(new { filePath });
        }

        [HttpPost]
        [Route("uploadmultiple")]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            List<string> filePaths = new List<string>();
            foreach (var file in files)
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file selected for upload.");
                }
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", file.FileName);
                filePaths.Add(filePath);
                // Ensure the directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return Ok(new { filePaths });
        }

        [HttpGet]
        [Route("download/{fileName}")]
        public IActionResult DownloadFile(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/octet-stream", fileName);
        }
    }
}


