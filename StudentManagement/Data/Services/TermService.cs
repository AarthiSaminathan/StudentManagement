using StudentManagement.Data.Models;
using StudentManagement.Data.ViewModels;

namespace StudentManagement.Data.Services
{
    public class TermService
    {
        private AppDbContext _context;

        public TermService(AppDbContext context)
        {
            _context = context;
        }

        public void AddTerm(TermVM term)
        {
            var _term = new Term()
            {
                TermName = term.TermName

            };
            _context.Add(_term);
            _context.SaveChanges();
        }


    }
}
