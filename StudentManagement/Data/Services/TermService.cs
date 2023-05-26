using StudentManagement.Data.Models;
using StudentManagement.Data.ViewModels;
using System.Threading.Tasks;

namespace StudentManagement.Data.Services
{
    public class TermService
    {
        private AppDbContext _context;
        private readonly ILogger<TermService> _logger;

        public TermService(AppDbContext context, ILogger<TermService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Term AddTermName(TermVM term)
        {
            _logger.LogInformation($"AddTermName:TermService", GetType().Name);
            var _term = new Term()
            {
                TermName = term.TermName

            };
            _context.Add(_term);
            _context.SaveChanges();
            _logger.LogInformation($"Mark{_term}");
            return _term;
        }


    }
}
