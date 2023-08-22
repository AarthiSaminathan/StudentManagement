using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StudentManagement.Controllers;
using StudentManagement.Data.Helper;
using StudentManagement.Data.Services;
using StudentManagement.Data.ViewModels;
using StudentManagement.MenuService;
using System.IO;

namespace StudentManagement.MenuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileValidationController : ControllerBase
    {
        public FileValidationService _fileValidationService;
        private readonly ILogger<FileValidationController> _logger;
        private readonly AppDbContext _context;

        public FileValidationController(AppDbContext context,FileValidationService fileValidationService, ILogger<FileValidationController> logger)
        {
            _fileValidationService = fileValidationService;
            _logger = logger;
            _context = context;

        }

        [HttpPost("add-file")]
        public IActionResult AddFile(FileValidationVM file)
        {
            _logger.LogInformation("Inside Controller:FileValidationController");
            _logger.LogInformation($"Calling AddFile");
            _fileValidationService.AddFile(file);
            _logger.LogInformation($"The response for the AddFile {JsonConvert.SerializeObject(file)}");
            return Ok();
            
        }
        [HttpGet("validate-file-name")]
        public IActionResult GetFile(String fileName)
        {
            _logger.LogInformation("Inside Controller:FileValidationController");
            _logger.LogInformation($"Calling GetFile");
            var file = _fileValidationService.GetFile();
            _logger.LogInformation($"The response for the GetFile {JsonConvert.SerializeObject(file)}");

            return Ok(file);
        }
    }
}
