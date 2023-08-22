using CsvHelper;
using Microsoft.AspNetCore.SignalR;
using StudentManagement.Data.Helper;
using StudentManagement.Data.Models;
using StudentManagement.Data.ViewModels;
using StudentManagement.MenuService;
using System.Globalization;

namespace StudentManagement.Data.Services
{
    public class StudentsService
    {
        private AppDbContext _context;
        private readonly ILogger<StudentsService> _logger;
        private readonly IHubContext<UploadHub> _hubContext;
        private readonly FileValidationService _fileValidationService;

        public StudentsService(AppDbContext context,ILogger<StudentsService> logger,IHubContext<UploadHub> hubContext,FileValidationService fileValidationService)
        {
            _context = context;
            _logger= logger;
            _hubContext= hubContext;
            _fileValidationService = fileValidationService;
        }

       
        public int AddStudent(StudentVM student)
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

        public async Task<List<Student>> AddStudentByFile(Stream file)
        {
            var reader = new StreamReader(file);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Student>().ToList();
            int chunckSize = 1000;
            int progress = 0;
            double uploadingRecords = 0;
            int totalRecords=records.Count;

            var newStudents=new List<Student>();
            for(int i=0; i<records.Count; i+=chunckSize) 
            { 
                var batch=records.Skip(i).Take(chunckSize).ToList();    
                foreach(var record in batch)
                {
                    var existingStudent=_context.Students.Find(record.Id);
                    if(existingStudent == null)
                    {
                        
                        var newStudent = new Student()
                        {
                            Id = record.Id,
                            Name = record.Name,
                            Standard = record.Standard,
                            AcademicYear = record.AcademicYear,
                            Gender = record.Gender
                        };
                        _context.Students.Add(newStudent);                   
                    }
                }
                _context.SaveChanges();
                uploadingRecords += batch.Count;
                progress += chunckSize;
                int percentCompleted = (int)((uploadingRecords*100 ) / totalRecords) ;
                await _hubContext.Clients.All.SendAsync("getProgress", (int)percentCompleted, (double)uploadingRecords,(double) totalRecords);
            
            }

            _logger.LogInformation($"Added {newStudents.Count} students from the file");
            return newStudents;

        }


        public List<StudentWithTermAndMarkVM> GetAllStudents()
        {
            _logger.LogInformation($"GetAllStudents:StudentsService", GetType().Name);
            var _allStudents = _context.Students.Select(student => new StudentWithTermAndMarkVM()
            {
                Id = student.Id,
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
