using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data.Services;
using StudentManagement.Data.ViewModels;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermsController : ControllerBase
    {
        private TermService _termService;

        public TermsController(TermService termService)
        {
            _termService = termService;
        }

        [HttpPost("add-term")]
        public IActionResult AddTerm(TermVM term)
        {
            _termService.AddTerm(term);
            return Ok();
        }
    }
}
