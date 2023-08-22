using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.Controllers;
using StudentManagement.Data.Services;
using StudentManagement.Data.ViewModels;
using StudentManagement.MenuService;

namespace StudentManagement.MenuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmenuController : ControllerBase
    {
        public SubmenuService _submenuService;

        private readonly ILogger<SubmenuController> _logger;

        public SubmenuController(SubmenuService submenuService, ILogger<SubmenuController> logger)
        {
            _submenuService = submenuService;
            _logger = logger;
        }

        [HttpPost("add-submenu")]
        public IActionResult AddSubmenu(SubmenuVM submenu)
        {
            _logger.LogInformation("Inside Controller:SubmenuController");
            _logger.LogInformation($"Calling AddSubmenu");
            var subMenu = _submenuService.AddSubmenu(submenu);
            _logger.LogInformation($"The response for the AddStudent {JsonConvert.SerializeObject(submenu)}");
            return Ok(subMenu);
        }
        [HttpGet("get-all-submenu")]
        public IActionResult GetAllSubmenu()
        {
            _logger.LogInformation("Inside Controller:SubmenuController");
            _logger.LogInformation($"Calling GetSubmenu");
            var allsubmenu = _submenuService.GetAllSubmenu();
            _logger.LogInformation($"The response for the GetAllStudents {JsonConvert.SerializeObject(allsubmenu)}");

            return Ok(allsubmenu);
        }

    }
}
