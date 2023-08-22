using Microsoft.EntityFrameworkCore;
using StudentManagement.Data.Models;
using StudentManagement.Data.Services;
using StudentManagement.Data.ViewModels;
using StudentManagement.Menu;
using System.Drawing;
using System.Text;

namespace StudentManagement.MenuService
{
    public class AdminDashboardService
    {
        private AppDbContext _context;
        private readonly ILogger<AdminDashboardService> _logger;
        private readonly HttpClient _httpClient;


        public AdminDashboardService(AppDbContext context, ILogger<AdminDashboardService> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        
        public int AddMenuWithSubmenu(AdminDashboardVM menu)
        {  
            _logger.LogInformation($"AddMenu:AdminDashboardService", GetType().Name);
            var _menu = new AdminDashboard()
            {
                menu = menu.menu,
                url = menu.url,
                iconUrl = ConvertImageUrlToBase64(menu.iconUrl), 
                parentId= menu.parentId,
                active = menu.active,


            };
            _context.Add(_menu);
            _context.SaveChanges();
            foreach(var id in menu.SubmenuId)
            {
                var _menu_submenu = new Menu_Submenu()
                {
                    AdmindashboardId = _menu.id,
                    SubmenuId = id
                };
                _context.Menu_Submenus.Add(_menu_submenu);
                _context.SaveChanges();

            }
            _logger.LogInformation($"Menu :{_menu}");
            return _menu.id;
        } 



        public List<AdminDashboardVM> GetAllMenusWithSubmenus()
        {
            _logger.LogInformation($"GetAllMenu:AdminDashboardService", GetType().Name);
            var _allMenu = _context.AdminDashboards
                .Select(menu => new AdminDashboardVM()
                {
                    menu = menu.menu,
                    url = menu.url,
                    iconUrl = menu.iconUrl,
                    parentId= menu.parentId,
                    active= menu.active
                }  ).ToList();
            _logger.LogInformation($"Menu{_allMenu}");
            return _allMenu;

        }

        private static string ConvertImageUrlToBase64(string imageUrl)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(imageUrl);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        
    }
}