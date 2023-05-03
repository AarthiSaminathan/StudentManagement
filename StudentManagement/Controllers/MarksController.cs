using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult AverageTerm()
        {
            var result=_markService.GetTotalMarks();
            return Ok(result);
        }
    }
}
