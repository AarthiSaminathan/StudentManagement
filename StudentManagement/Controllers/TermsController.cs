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
    public class TermsController : ControllerBase
    {
        private TermService _termService;
        private readonly ILogger<TermsController> _logger;

        public TermsController(TermService termService, ILogger<TermsController> logger)
        {
            _termService = termService;
            _logger = logger;
        }

        [HttpPost("add-term")]
        public IActionResult AddTerm(TermVM term)
        {
            _logger.LogInformation("Inside Controller:Termscontroller");
            _logger.LogInformation($"Calling AddTerm");
            _termService.AddTermName(term);
             _logger.LogInformation($"The response for the AddTerm {JsonConvert.SerializeObject(term)}");
            return Ok();
        }
    }
}
