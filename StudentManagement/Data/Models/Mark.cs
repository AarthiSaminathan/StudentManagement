using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Data.Models
{
    public class Mark
    {
        
        public int Id { get; set; }
        public int StudentId { get; set; }
        [Range(1,6)]
        public int TermId { get; set; }
        [Range(0,100,ErrorMessage ="Enter valid Mark")]
        public int Tamil { get; set; }
        [Range(0, 100, ErrorMessage = "Enter valid Mark")]
        public int English { get; set; }
        [Range(0, 100, ErrorMessage = "Enter valid Mark")]
        public int Maths { get; set; }
        [Range(0, 100, ErrorMessage = "Enter valid Mark")]
        public int Physics { get; set; }
        [Range(0, 100, ErrorMessage = "Enter valid Mark")]
        public int Chemistry { get; set; }
        [Range(0, 100, ErrorMessage = "Enter valid Mark")]
        public int ComputerScience { get; set; }


        public Student Student { get; set; }
       public Term Term { get; set; }

       
    }
}
