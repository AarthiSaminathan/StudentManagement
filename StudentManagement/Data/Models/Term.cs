using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Data.Models
{
    public class Term
    {
        [Range(1, 6,ErrorMessage ="Enter Valid Term")]
        public int Id { get; set; }
        public string TermName { get; set; }
    }
} 