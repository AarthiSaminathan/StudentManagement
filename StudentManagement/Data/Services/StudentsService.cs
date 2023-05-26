 using StudentManagement.Data.Models;
using StudentManagement.Data.ViewModels;

namespace StudentManagement.Data.Services
{
    public class StudentsService
    {
        private AppDbContext _context;
        private readonly ILogger<StudentsService> _logger;


        public StudentsService(AppDbContext context,ILogger<StudentsService> logger)
        {
            _context = context;
            _logger= logger;
        }

       
        public int AddStudentWithTerm(StudentVM student)
        {
            _logger.LogInformation($"AddStudentWithTerm:StudentsService",GetType().Name);
            var _student = new Student()
            {
                Name = student.Name,
                Standard = student.Standard,
                AcademicYear = student.AcademicYear,
                Gender = student.Gender
   

            };
            _context.Add(_student);
            _context.SaveChanges();
            _logger.LogInformation($"Student {student.Name}");
            return _student.Id;
        }

      

        public List<StudentWithTermAndMarkVM> GetAllStudents()
        {
            _logger.LogInformation($"GetAllStudents:StudentsService", GetType().Name);
            var _allStudents = _context.Students.Select(student => new StudentWithTermAndMarkVM()
            {
                Name = student.Name,
                Standard = student.Standard,
                AcademicYear = student.AcademicYear,
                Gender = student.Gender
             }).ToList();
            _logger.LogInformation($"Student{_allStudents}");
            return _allStudents;
            
        }

        public StudentWithTermAndMarkVM GetStudentById(int rollno)
        {
            _logger.LogInformation($"GetStudentById:StudentsService", GetType().Name);
            var _student = _context.Students.Where(n => n.Id == rollno).Select(student => new StudentWithTermAndMarkVM()
            {
                Name = student.Name,
                Standard = student.Standard,
                AcademicYear = student.AcademicYear,
                Gender = student.Gender
            }).FirstOrDefault();
            _logger.LogInformation($"Student{_student}");
            return _student;
        }

        
        public Student UpdateStudentById(int rollno, StudentVM student)
        {
            _logger.LogInformation($"UpdateStudentById:StudentsService", GetType().Name);
            var _student = _context.Students.FirstOrDefault(n => n.Id == rollno);
            if (_student != null)
            {
                
                _student.Name = student.Name;
                _student.Standard = student.Standard;
                _student.AcademicYear = student.AcademicYear;
                _student.Gender = student.Gender;
                _context.SaveChanges();
            }
            _logger.LogInformation($"Student{_student}");
            return _student;
        }

        public void DeleteStudentById(int rollno)
        {
            _logger.LogInformation($"DeleteStudentById:StudentsService", GetType().Name);
            var _student = _context.Students.FirstOrDefault(n => n.Id== rollno);
            if (_student != null)
            {
                _context.Students.Remove(_student);
                _context.SaveChanges();
            }
            _logger.LogInformation($"Student{_student}");

        }


    }
}
