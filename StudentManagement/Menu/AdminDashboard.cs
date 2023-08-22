using System.Security.Policy;
using System.Text;

namespace StudentManagement.Menu
{
    public class AdminDashboard
    {
        public int id { get; set; }
        public string menu { get; set; }
        public string url { get; set; }
        public string iconUrl { get; set; }
        public int parentId { get;set; }
        public string active { get;set; }

        public List<Menu_Submenu> Menu_Submenus { get; set; }


    }


}


