using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.Data.Models;
using StudentManagement.Data.Services;
using StudentManagement.Data.ViewModels;


namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public StudentsService _studentsService;

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(StudentsService studentsService,ILogger<StudentsController> logger )
        {
            _studentsService = studentsService;
            _logger = logger;
        }
            
        [HttpPost("add-student-with-term")]
        public IActionResult AddStudent(StudentVM student)
        {
            _logger.LogInformation("Inside Controller:StudentController");
            _logger.LogInformation($"Calling AddStudent");
            var studentDetails=_studentsService.AddStudentWithTerm(student);
            _logger.LogInformation($"The response for the AddStudent {JsonConvert.SerializeObject(student)}");
            return Ok(studentDetails);
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
