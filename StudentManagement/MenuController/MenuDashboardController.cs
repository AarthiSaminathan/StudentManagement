﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.Data.ViewModels;
using StudentManagement.MenuService;

namespace StudentManagement.MenuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuDashboardController : ControllerBase
    {
        public MenuDashboardService _menuDashboardService;

        private readonly ILogger<MenuDashboardController> _logger;

        public MenuDashboardController(MenuDashboardService menuDashboardService, ILogger<MenuDashboardController> logger)
        {
            _menuDashboardService = menuDashboardService;
            _logger = logger;
        }

        [HttpPost("add-Menu")]
        public IActionResult AddMenuWithSubmenu(MenuDasboardVM menu)
        {
            _logger.LogInformation("Inside Controller:MenuDashboardController");
            _logger.LogInformation($"Calling GetAllMenu");
            var menuDetails = _menuDashboardService.AddMenuWithSubmenu(menu);
            _logger.LogInformation($"The response for the GetAllMenu {JsonConvert.SerializeObject(menu)}");
            return Ok(menuDetails);
        }
        [HttpGet("get-all-menu")]
        public IActionResult GetAllMenusWithSubmenus()
        {
            _logger.LogInformation("Inside Controller:MenuDashboardController");
            _logger.LogInformation($"Calling GetAllMenu");
            var allmenu = _menuDashboardService.GetAllMenusWithSubmenus();
            _logger.LogInformation($"The response for the GetAllMenu {JsonConvert.SerializeObject(allmenu)}");

            return Ok(allmenu);
        }


    }
}

