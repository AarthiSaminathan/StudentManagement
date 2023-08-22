namespace StudentManagement.Menu
{
    public class Menu_Submenu
    {
        public int Id { get; set; }

        public int AdmindashboardId { get; set; }
        public AdminDashboard AdminDashboard { get; set; }  

        public int SubmenuId { get; set; }
        public Submenu Submenu { get; set; }
       
    }

}
