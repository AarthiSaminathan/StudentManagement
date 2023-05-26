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

    public class MarkDetailsVM
    {
        public int Id { get; set; }

        public int Tamil { get; set; }
        public int English { get; set; }
        public int Maths { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int ComputerScience { get; set; }

    }

}
