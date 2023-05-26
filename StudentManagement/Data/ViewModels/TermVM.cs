using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Data.ViewModels
{
    public class TermVM
    {
        [Range(1, 6, ErrorMessage = "Enter Valid Term")]
        public int Id { get; set; }

        public string TermName { get; set; }
    }
}
 