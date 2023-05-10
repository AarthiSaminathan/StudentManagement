using StudentManagement.Data.Models; 
using StudentManagement.Data.ViewModels;
using System.Threading.Tasks;

namespace StudentManagement.Data.Services
{
    public class MarkService
    {
        private AppDbContext _context;

        public MarkService(AppDbContext context)
        {
            _context = context;
        }

        public void AddMark(MarkVM mark)
        {
            var _mark = new Mark()
            {
                StudentId = mark.StudentId,
                TermId = mark.TermId,
                Tamil = mark.Tamil,
                English = mark.English,
                Maths = mark.Maths,
                Physics = mark.Physics,
                Chemistry = mark.Chemistry,
                ComputerScience = mark.ComputerScience



            };
            _context.Marks.Add(_mark);
            _context.SaveChanges();

        }

        //public List<StudentsDetails> GetTotalMarks(int academicYear)
        //{


        //    var getTotal = _context.Marks.Where(x=>x.Student.AcademicYear==academicYear).Select(g => new
        //    {

        //        StudentName = g.Student.Name,
        //        TermName = g.Term.TermName,
        //        Percentage = (g.Tamil + g.English + g.Maths + g.Physics + g.Chemistry + g.ComputerScience) / 6

        //    }).Where(p => p.Percentage >= 80).ToList();

        //    //return getTotal;

        //    List<StudentsDetails> studentList = new List<StudentsDetails>();
        //    foreach (var student in getTotal)
        //    {
        //        var studentDemo=studentList.Where(s=>s.StudentName==student.StudentName).FirstOrDefault();
        //        MarksDetails marksDetails = new MarksDetails();
        //        marksDetails.TermName=student.TermName;
        //        marksDetails.Percentage = student.Percentage;

        //        if(studentDemo == null)
        //        {
        //            StudentsDetails studentsDetails = new StudentsDetails();
        //            studentsDetails.StudentName = student.StudentName;
        //            List<MarksDetails> marksList = new List<MarksDetails>();
        //            marksList.Add(marksDetails);
        //            studentsDetails.marks = marksList;
        //            studentList.Add(studentsDetails);

        //        }
        //        else
        //        {
        //            studentDemo.marks.Add(marksDetails);
        //        }
        //    }
        //    return studentList;
        //}

        public Dictionary<string, Dictionary<string, int>> GetTotalMarks(int academicYear)
        {


            var getTotal = _context.Marks.Where(x => x.Student.AcademicYear == academicYear).Select(g => new
            {

                StudentName = g.Student.Name,
                TermName = g.Term.TermName,
                Percentage = (g.Tamil + g.English + g.Maths + g.Physics + g.Chemistry + g.ComputerScience) / 6

            }).Where(p => p.Percentage >= 80).ToList();

            //return getTotal;

            Dictionary<string, Dictionary<string, int>> markStatus = new Dictionary<string, Dictionary<string, int>>();
            foreach (var student in getTotal)
            {
                var studentDemo = markStatus.Where(s => s.Key == student.StudentName).FirstOrDefault();
                if (studentDemo.Value == null)
                {
                    markStatus.Add(student.StudentName, new Dictionary<string, int>()
                    {
                    {student.TermName,(int)student.Percentage}

                    });
                }
                else
                {
                    studentDemo.Value.Add(student.TermName, student.Percentage);

                }

            }
            return markStatus;
        }

        public Dictionary<string, Dictionary<string, double>> GetOveralTotalMarks(int academicYear)
        {

            var getTotal = _context.Marks.Where(x => x.Student.AcademicYear == academicYear).Select(n => new
            {
                StudentName = n.Student.Name,
                TermName = n.Term.TermName,
                Percentage = (n.Tamil + n.English + n.Maths + n.Physics + n.Chemistry + n.ComputerScience) / 6
            });

            Dictionary<string, Dictionary<string, double>> markStatus = new Dictionary<string, Dictionary<string, double>>();

            foreach (var marks in getTotal)
            {
                var tp = marks.Percentage;
                var studentDemo = markStatus.Where(s => s.Key == marks.StudentName).FirstOrDefault();
                if (studentDemo.Value == null)
                {

                    markStatus.Add(marks.StudentName, new Dictionary<string, double>()
                    {
                        {"OverallPercentage",marks.Percentage }
                    });
                }
                else
                {
                    var overallmarks = 0.0;
                    var overallPercentage = studentDemo.Value.TryGetValue("OverallPercentage", out overallmarks);
                    overallmarks = overallmarks + marks.Percentage;
                    studentDemo.Value.Remove("OverallPercentage");
                    studentDemo.Value.Add("OverallPercentage", overallmarks);

                }

            }
            Dictionary<string, Dictionary<string, double>> FinalResult = new Dictionary<string, Dictionary<string, double>>();
            foreach (KeyValuePair<string, Dictionary<string, double>> result in markStatus)
            {
                var overallmarks = 0.0;
                var overallPercentage = result.Value.TryGetValue("OverallPercentage", out overallmarks);
                overallmarks = Math.Round(overallmarks / 6,1);

                if (overallmarks > 70)
                {
                    FinalResult.Add(result.Key, new Dictionary<string, double>()
                    {
                        {"OverallPercentage",overallmarks }
                    });

                }
            }
            return FinalResult;
        }

        public Dictionary<string, Dictionary<string, int>> GetSubjectWiseMarks(int academicYear,string subject)
        {
            var subjectMarks = _context.Marks.Where(x=>x.Student.AcademicYear==academicYear).Select(m =>  new
            {
                StudentName=m.Student.Name,
                TermName=m.Term.TermName,
                Marks=subject.Equals("Physics")?m.Physics:subject.Equals("Chemistry")?m.Chemistry: subject.Equals("ComputerScience") ? m.ComputerScience: 
                subject.Equals("English") ? m.English: subject.Equals("Tamil") ? m.Tamil:m.Maths

            }).Where(x=>x.Marks>=70).ToList();
            Dictionary<string, Dictionary<string, int>> markList = new Dictionary<string, Dictionary<string, int>>();
            foreach(var mark in subjectMarks)
            {
                var marks=markList.Where(x=>x.Key==mark.StudentName).FirstOrDefault();
                if(marks.Value==null)
                {
                    markList.Add(mark.StudentName, new Dictionary<string, int>
                    {
                        {mark.TermName, mark.Marks}

                    });
                }
                else
                {
                    marks.Value.Add(mark.TermName,mark.Marks);
                }
            }
            
            return markList;
        }   
        
        public Dictionary<string,Dictionary<string,double>> GetSubjectWiseOverAllPercentage(int academicYear,string subject)
        {
            var subjectMarks = _context.Marks.Where(x => x.Student.AcademicYear == academicYear).Select(m => new
            {
                StudentName = m.Student.Name,
                TermName = m.Term.TermName,
                Marks = subject.Equals("Physics") ? m.Physics : subject.Equals("Chemistry") ? m.Chemistry : subject.Equals("ComputerScience") ? m.ComputerScience :
                subject.Equals("English") ? m.English : subject.Equals("Tamil") ? m.Tamil : m.Maths
            });
            Dictionary<string, Dictionary<string, double>> overallMarkList = new Dictionary<string, Dictionary<string, double>>();
            foreach(var marklist in subjectMarks)
            {
                var list = marklist.Marks;
                var result = overallMarkList.Where(s => s.Key == marklist.StudentName).FirstOrDefault();
                if (result.Value == null)
                {

                    overallMarkList.Add(marklist.StudentName, new Dictionary<string, double>()
                    {
                        {"SubjectWiseOverallPercentage",marklist.Marks }
                    });
                }
                else
                {
                    var overallmarks = 0.0;
                    var subjectWiseOverallPercentage = result.Value.TryGetValue("SubjectWiseOverallPercentage", out overallmarks);
                    overallmarks = overallmarks + marklist.Marks;
                    result.Value.Remove("SubjectWiseOverallPercentage");
                    result.Value.Add("SubjectWiseOverallPercentage", overallmarks);
                }
            }
            Dictionary<string, Dictionary<string, double>> FinalResult = new Dictionary<string, Dictionary<string, double>>();
            foreach (KeyValuePair<string, Dictionary<string, double>> result in overallMarkList)
            {
                var overallmarks = 0.0;
                var subjectWiseOverallPercentage = result.Value.TryGetValue("SubjectWiseOverallPercentage", out overallmarks);
                overallmarks = Math.Round(overallmarks / 6,1);

                if (overallmarks>=70)
                {
                    FinalResult.Add(result.Key, new Dictionary<string, double>()
                    {
                        {"SubjectWiseOverallPercentage",overallmarks }
                    });

                }
            }
            return FinalResult;
        }
    }

    

}







