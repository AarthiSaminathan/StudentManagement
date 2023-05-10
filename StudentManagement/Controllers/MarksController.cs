using Microsoft.AspNetCore.Http;
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

        public MarksController(MarkService markService)
        {
            _markService = markService;
        }

        [HttpPost("add-mark")]
        public IActionResult AddTerm(MarkVM mark)
        {
            _markService.AddMark(mark);
            return Ok();
        }
        //[HttpGet("get-percentage-above-eighty")]
        //public IActionResult GetTermWisePercentage(int academicYear)
        //{

        //    var result=_markService.GetTotalMarks(academicYear);
        //    return Ok(JsonConvert.SerializeObject(result));
        //}

        [HttpGet("get-percentage-above-eighty")]
        public IActionResult GetTermWisePercentage(int academicYear)
        {

            Dictionary<string, Dictionary<string, int>> result =_markService.GetTotalMarks(academicYear);
            return Ok(result);
        }

        [HttpGet("get-percentage-above-eighty-overall")]
        public IActionResult GetOvetallPercenageAboveEighty(int academicYear)
        {

            Dictionary<string, Dictionary<string, double>> result = _markService.GetOveralTotalMarks(academicYear);
            return Ok(result);
        }

        [HttpGet("get-subjectwise-mark-above-eighty")]
        public IActionResult GetSubjectWiseMarksAboveEighty(int academicYear,string subject)
        {

            Dictionary<string, Dictionary<string, int>> result = _markService.GetSubjectWiseMarks(academicYear,subject);
            return Ok(result);
        }

        [HttpGet("get-subjectwise-mark-above-eighty-overall")]
        public IActionResult GetSubjectWiseOverAllPercentageAboveEighty(int academicYear,string subject)
        {

            Dictionary<string, Dictionary<string, double>> result = _markService.GetSubjectWiseOverAllPercentage(academicYear,subject);
            return Ok(result);
        }

    }
}
