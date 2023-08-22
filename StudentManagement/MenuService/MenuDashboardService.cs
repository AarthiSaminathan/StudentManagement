using StudentManagement.Data.Models;
using StudentManagement.Data.ViewModels;
using StudentManagement.Menu;

namespace StudentManagement.MenuService
{
    public class MenuDashboardService
    {
        private AppDbContext _context;
        private readonly ILogger<MenuDashboardService> _logger;
        private readonly HttpClient _httpClient;


        public MenuDashboardService(AppDbContext context, ILogger<MenuDashboardService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public int AddMenuWithSubmenu(MenuDasboardVM menu)
        {
            _logger.LogInformation($"AddMenu:MenuDashboardService", GetType().Name);
            var _menu = new MenuDashboard()
            {
                menu = menu.menu,
                url = menu.url,
                iconUrl = ConvertImageUrlToBase64(menu.iconUrl),
                parentId = menu.parentId,
                active = menu.active


            };
            _context.Add(_menu);
            _context.SaveChanges();
            _logger.LogInformation($"Menu {menu.menu}");
            return _menu.id;
        }



        public List<MenuDasboardVM> GetAllMenusWithSubmenus()
        {
            _logger.LogInformation($"GetAllMenu:MenuDashboardService", GetType().Name);
            var _allMenu = _context.MenuDashboard
                .Select(menu => new MenuDasboardVM()
                {
                    menu = menu.menu,
                    url = menu.url,
                    iconUrl = menu.iconUrl,
                    parentId = menu.parentId,
                    active = menu.active
                }).ToList();
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

