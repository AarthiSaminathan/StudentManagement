using Org.BouncyCastle.Crmf;
using StudentManagement.Menu;
using System.Security.Policy;
using System.Text;

namespace StudentManagement.Data.ViewModels
{
    public class AdminDashboardVM
    {
        public string menu { get; set; }
        public string url { get; set; }
        public string iconUrl { get; set; }
        public int parentId { get; set; }
        public string active { get; set; }


        public List<int> SubmenuId { get; set; }
        

    }

    
    
}
        


    
    

  

