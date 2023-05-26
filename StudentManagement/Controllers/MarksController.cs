using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.Data.Services;
using StudentManagement.Data.ViewModels;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private MarkService _markService;
        private readonly ILogger<MarksController> _logger;


        public MarksController(MarkService markService, ILogger<MarksController> logger)
        {
            _markService = markService;
            _logger = logger;
        }

        [HttpPost("add-mark")]
        public IActionResult AddTermMark(MarkVM mark)
        {
            try
            {
                if(_markService.TermCount(mark.TermId,mark.StudentId)<1)
                {
                    _logger.LogInformation("Inside Controller:Markscontroller");
                    _logger.LogInformation($"Calling AddTermMark");
                    var marks = _markService.AddMark(mark);
                    _logger.LogInformation($"The response for the AddTermMarks {JsonConvert.SerializeObject(mark)}");
                    return Ok(marks);
                }
                else
                {
                    return BadRequest("Repeated TermId is found");
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation("Invalid Marks added");
                return BadRequest(ex.Message);
            }
        }
       
        [HttpGet("get-percentage-above-eighty")]
        public IActionResult GetTermWisePercentage(int academicYear,int percentage)
        {
            try
            {
                _logger.LogInformation("Inside Controller:Markscontroller");
                _logger.LogInformation($"Calling GetTermWisePercentage");
                Dictionary<string, Dictionary<string, int>> result = _markService.GetTotalMarks(academicYear,percentage);
                _logger.LogInformation($"The response for the GetTermWisePercentageAboveEighty{JsonConvert.SerializeObject(result)}");
                return Ok(result);
            }
            catch
            {
                _logger.LogInformation("Not Found");
                return BadRequest();
            }
        }

        [HttpGet("get-percentage-above-eighty-overall")]
        public IActionResult GetOvetallPercenageAboveEighty(int academicYear,int percentage)
        {
            try
            {
                _logger.LogInformation("Inside Controller:Markscontroller");
                _logger.LogInformation($"Calling GetTermWisePercentage");
                Dictionary<string, double> result = _markService.GetOverallTotalMarks(academicYear, percentage);
                _logger.LogInformation($"The response for the GetOvetallPercenageAboveEighty{JsonConvert.SerializeObject(result)}");
                return Ok(result);
            }
            catch 
            {
                _logger.LogInformation("Not Found");
                return BadRequest(); 
            }
        }

        [HttpGet("get-subjectwise-mark-above-eighty")]
        public IActionResult GetSubjectWiseMarksAboveEighty(int academicYear,string subject,int percentage)
        {
            try
            {
                _logger.LogInformation("Inside Controller:Markscontroller" );
                _logger.LogInformation($"Calling GetSubjectWiseMarksAboveEighty");
                Dictionary<string, Dictionary<string, int>> result = _markService.GetSubjectWiseMarks(academicYear, subject,percentage);
                _logger.LogInformation($"The response for the GetSubjectWiseMarksAboveEighty{JsonConvert.SerializeObject(result)}");
                return Ok(result);
            }
            catch 
            {
                _logger.LogInformation("Not Found");
                return BadRequest();
            }

        }

        [HttpGet("get-subjectwise-mark-above-eighty-overall")]
        public IActionResult GetSubjectWiseOverAllPercentageAboveEighty(int academicYear,string subject,int percentage)
        {
            try
            {
                _logger.LogInformation("Inside Controller:Markscontroller");
                _logger.LogInformation($"Calling GetSubjectWiseOverAllPercentageAboveEighty");
                Dictionary<string, double> result = _markService.GetSubjectWiseOverAllPercentage(academicYear, subject, percentage);
                _logger.LogInformation($"The response for the GetSubjectWiseOverAllPercentageAboveEighty{JsonConvert.SerializeObject(result)}");
                return Ok(result);
            }
            catch
            {
                _logger.LogInformation("Not Found");
                return BadRequest(); 
            }

        }

    }
}
