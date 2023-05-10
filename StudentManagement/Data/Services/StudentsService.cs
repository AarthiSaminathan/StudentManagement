using StudentManagement.Data.Models;
using StudentManagement.Data.ViewModels;

namespace StudentManagement.Data.Services
{
    public class StudentsService
    {
        private AppDbContext _context;

        public StudentsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddStudentWithTerm(StudentVM student)
        {
            var _student = new Student()
            {
                Id = student.Id,
                RollNo = student.RollNo,
                Name = student.Name,
                Standard = student.Standard,
                AcademicYear = student.AcademicYear,
                Gender = student.Gender
   

            };
            _context.Add(_student);
            _context.SaveChanges();

            //foreach(var id in student.MarkId)
            //{
            //    var _student_term = new StudentTerm()
            //    {
            //        StudentId = _student.Id,
            //        TermId = id
            //    };
            //    _context.Students.Add(_student_term);
            //    _context.SaveChanges();
            //}
        }

      

        public List<StudentWithTermAndMarkVM> GetAllStudents()
        {
            var _allStudents = _context.Students.Select(student => new StudentWithTermAndMarkVM()
            {
                RollNo = student.RollNo,
                Name = student.Name,
                Standard = student.Standard,
                AcademicYear = student.AcademicYear,
                Gender = student.Gender,
                
                
             }).ToList();
            return _allStudents;
            
        }

        public StudentWithTermAndMarkVM GetStudentById(int rollno)
        {
            var _student = _context.Students.Where(n => n.RollNo == rollno).Select(student => new StudentWithTermAndMarkVM()
            {
                RollNo = student.RollNo,
                Name = student.Name,
                Standard=student.Standard,
                AcademicYear=student.AcademicYear,
                Gender = student.Gender,
                
            }).FirstOrDefault();

            return _student;
        }

       
          
        
        

        public Student UpdateStudentById(int rollno, StudentVM student)
        {
            var _student = _context.Students.FirstOrDefault(n => n.RollNo == rollno);
            if (_student != null)
            {
                
                _student.RollNo = student.RollNo;
                _student.Name = student.Name;
                _student.Standard = student.Standard;
                _student.AcademicYear = student.AcademicYear;
                _student.Gender = student.Gender;
                _context.SaveChanges();
            }
            return _student;
        }

        public void DeleteStudentById(int rollno)
        {
            var _student = _context.Students.FirstOrDefault(n => n.RollNo== rollno);
            if (_student != null)
            {
                _context.Students.Remove(_student);
                _context.SaveChanges();
            }

        }


    }
}
