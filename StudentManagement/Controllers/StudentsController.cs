using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public StudentsController(StudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpPost("add-student-with-term")]
        public IActionResult AddStudent(StudentVM student)
        {
            _studentsService.AddStudentWithTerm(student);
            return Ok();
        }

        //[HttpGet("get-all-student")]
        //public IActionResult GetAllStudents() 
        //{
        //    var allstudents= _studentsService.GetAllStudents();
        //    return Ok(allstudents);
        //}

        //[HttpGet("get-termpercentage-above-eighty")]
        //public IActionResult GetTermPercentageAboveEighty(int rollno,int academicyear)
        //{
        //    var termpercentage = _studentsService.GetTermPercentageAboveEighty( rollno, academicyear);
        //    return Ok(termpercentage);
        //}

        [HttpGet("get-student-by-rollno/{rollno}")]
        public IActionResult GetStudentById(int rollno) 
        {
            var student = _studentsService.GetStudentById(rollno);
            return Ok(student);

        }

        [HttpPut("update-student-by-rollno/{rollno}")]
        public IActionResult UpdateStudentById(int rollno, StudentVM student)
        {
            var upadateStudent = _studentsService.UpdateStudentById(rollno, student);
            return Ok(upadateStudent);

        }

        [HttpDelete("delete-student-by-rollno/{rollno}")]
        public IActionResult DeleteStudentById(int rollno)
        {
            _studentsService.DeleteStudentById(rollno);
            return Ok();
        }





    }
}
