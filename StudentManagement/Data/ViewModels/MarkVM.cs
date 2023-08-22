using StudentManagement.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Data.ViewModels
{
    public class MarkVM
    {
        public int StudentId { get; set; }

        [Range(1, 6)]
        public int TermId { get; set; }
        [Range(0, 100, ErrorMessage = "Enter valid Mark")]

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

        //public List<int> TermId { get; set; }

    }

    

}
