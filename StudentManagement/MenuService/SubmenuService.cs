using StudentManagement.Data.Models;
using StudentManagement.Data.Services;
using StudentManagement.Data.ViewModels;
using StudentManagement.Menu;

namespace StudentManagement.MenuService
{
    public class SubmenuService
    {
        private AppDbContext _context;
        private readonly ILogger<SubmenuService> _logger;


        public SubmenuService(AppDbContext context, ILogger<SubmenuService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public Submenu AddSubmenu(SubmenuVM submenu)
        {
            _logger.LogInformation($"AddSubmenu:SubmenuService", GetType().Name);

            var _submenu = new Submenu()
            {
                name = submenu.name,
                url = submenu.url

            };

            _context.Submenus.Add(_submenu);
            _context.SaveChangesAsync();
            _logger.LogInformation($"Submenu{_submenu}");
            return _submenu;
        }




        public List<SubmenuVM> GetAllSubmenu()
        {
            _logger.LogInformation($"GetAllSubmenu:SubmenuService", GetType().Name);
            var _allSubmenu = _context.Submenus.Select(submenu => new SubmenuVM()
            {
                name = submenu.name,
                url = submenu.url
            }).ToList();
            _logger.LogInformation($"Student{_allSubmenu}");
            return _allSubmenu;

        }
    }
}
