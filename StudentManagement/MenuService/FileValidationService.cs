using StudentManagement.Data.Helper;
using StudentManagement.Data.Models;
using StudentManagement.Data.ViewModels;
using StudentManagement.Menu;
using System.IO;

namespace StudentManagement.MenuService
{
    public class FileValidationService
    {

        private readonly AppDbContext _context;
        private readonly ILogger<FileValidationService> _logger;

        public FileValidationService(AppDbContext context, ILogger<FileValidationService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public void AddFile(FileValidationVM file)
        {
            _logger.LogInformation($"AddFile:FileValidationService", GetType().Name);
                var _file = new FileValidation()
                {
                    FileName = file.FileName

                };
                _context.Add(_file);
                _context.SaveChanges();
                _logger.LogInformation($"File {file.FileName}");
                
            
        }
        public List<FileValidationVM> GetFile()
        {
            _logger.LogInformation($"GetFile:FileValidationService", GetType().Name);
            var _file = _context.FileValidation.Select(file => new FileValidationVM()
            {
               FileName= file.FileName
            }).ToList();
            _logger.LogInformation($"Retrived{_file.Count} files");
            return _file;

        }
    }

  }
    
