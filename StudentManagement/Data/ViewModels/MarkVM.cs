using StudentManagement.Data.Models;

namespace StudentManagement.Data.ViewModels
{
    public class MarkVM
    {
        public int Id { get; set; }
        public int Tamil { get; set; }
        public int English { get; set; }
        public int Maths { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int ComputerScience { get; set; }

        public int StudentId { get; set; }
        public List<int> TermId { get; set; }

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
