using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using StudentManagement.Data.Helper;
using StudentManagement.Data.Models;
using StudentManagement.Data.Services;
using StudentManagement.Data.ViewModels;
using StudentManagement.MenuService;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public StudentsService _studentsService;
        public FileValidationService _fileValidationService;
        private readonly ILogger<StudentsController> _logger;
        private readonly IHubContext<UploadHub> _hubContext;
        private readonly AppDbContext _context;
        public StudentsController(AppDbContext context,StudentsService studentsService,ILogger<StudentsController> logger, FileValidationService fileValidationService,IHubContext<UploadHub> hubContext)
        {
            _studentsService = studentsService;
            _logger = logger;
            _hubContext = hubContext;
            _context = context;
            _fileValidationService = fileValidationService;
        }
            
        [HttpPost("add-student")]
        public IActionResult AddStudent(StudentVM student)
        {
            _logger.LogInformation("Inside Controller:StudentController");
            _logger.LogInformation($"Calling AddStudent");
            var studentDetails=_studentsService.AddStudent(student);
            _logger.LogInformation($"The response for the AddStudent {JsonConvert.SerializeObject(student)}");     
            return Ok(studentDetails);
        }
        [HttpPost("add-student-by-file")]
        public async Task<IActionResult> AddStudentByFile(IFormFile file)
        {
            var Filename = file.FileName;
            var Files = file.OpenReadStream();
            _logger.LogInformation("Inside Controller:StudentController");
            _logger.LogInformation($"Calling AddStudent");
            if (_context.FileValidation.Any(f => f.FileName == Filename))
            {
                _logger.LogInformation($"File {Filename} already exists.");
                return BadRequest("File already exists");
            }
            else
            {
                var student = _studentsService.AddStudentByFile(file.OpenReadStream());
                _logger.LogInformation($"The response for the AddStudent {JsonConvert.SerializeObject(file)}");
                return Ok(student);
            }
        }


        [HttpGet("get-all-student")]
        public IActionResult GetAllStudents()
        {
            _logger.LogInformation("Inside Controller:StudentController");
            _logger.LogInformation($"Calling GetAllStudents");
            var allstudents = _studentsService.GetAllStudents();
            _logger.LogInformation($"The response for the GetAllStudents {JsonConvert.SerializeObject(allstudents)}");

            return Ok(allstudents);
        }

        

        [HttpGet("get-student-by-rollno/{rollno}")]
        public IActionResult GetStudentById(int rollno) 
        {
            _logger.LogInformation("Inside Controller:StudentController");
            _logger.LogInformation($"Calling GetStudentById");
            var student = _studentsService.GetStudentById(rollno);
            _logger.LogInformation($"The response for the GetStudentByRollno{JsonConvert.SerializeObject(student)}");

            return Ok(student);

        }

        [HttpPut("update-student-by-rollno/{rollno}")]
        public IActionResult UpdateStudentById(int rollno, StudentVM student)
        {
            _logger.LogInformation("Inside Controller:StudentController");
            _logger.LogInformation($"Calling UpdateStudentById");
            var upadateStudent = _studentsService.UpdateStudentById(rollno, student);
            _logger.LogInformation($"The response for the UpdateStudent{JsonConvert.SerializeObject(student)}");

            return Ok(upadateStudent);

        }

        [HttpDelete("delete-student-by-rollno/{rollno}")]
        public IActionResult DeleteStudentById(int rollno)
        {
            _logger.LogInformation("Inside Controller:StudentController");
            _logger.LogInformation($"Calling DeleteStudentById");
            _studentsService.DeleteStudentById(rollno);
            _logger.LogInformation($"The response for the DeleteStudent student management is{JsonConvert.SerializeObject(rollno)}");

            return Ok();
        }





    }
}
