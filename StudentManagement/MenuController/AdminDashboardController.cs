using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.Controllers;
using StudentManagement.Data.Services;
using StudentManagement.Data.ViewModels;
using StudentManagement.Menu;
using StudentManagement.MenuService;

namespace StudentManagement.MenuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashboardController : ControllerBase
    {
        public AdminDashboardService _adminDashboardService;

        private readonly ILogger<AdminDashboardController> _logger;

        public AdminDashboardController(AdminDashboardService adminDashboardService, ILogger<AdminDashboardController> logger)
        {
            _adminDashboardService = adminDashboardService;
            _logger = logger; 
        }

        [HttpPost("add-Menu")]
        public IActionResult AddMenuWithSubmenu(AdminDashboardVM menu)
        {
            _logger.LogInformation("Inside Controller:AdminDashboardController");
            _logger.LogInformation($"Calling GetAllMenu");
            var menuDetails = _adminDashboardService.AddMenuWithSubmenu(menu);
            _logger.LogInformation($"The response for the GetAllMenu {JsonConvert.SerializeObject(menu)}");
            return Ok(menuDetails);
        }
        [HttpGet("get-all-menu")]
        public IActionResult GetAllMenusWithSubmenus()
        {
            _logger.LogInformation("Inside Controller:AdminDashboardController");
            _logger.LogInformation($"Calling GetAllMenu");
            var allmenu = _adminDashboardService.GetAllMenusWithSubmenus();
            _logger.LogInformation($"The response for the GetAllMenu {JsonConvert.SerializeObject(allmenu)}");

            return Ok(allmenu);
        }


    }
}
