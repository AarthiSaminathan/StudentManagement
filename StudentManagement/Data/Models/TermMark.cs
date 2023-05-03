namespace StudentManagement.Data.Models
{
    public class TermMark
    {
        public int Id { get; set; }

        public int TermId { get; set; }
        public Term Term { get; set; }
        public int MarkId { get; set; }
        public Mark Mark { get; set; }
    }
}
