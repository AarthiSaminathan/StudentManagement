using StudentManagement.Controllers;
using StudentManagement.Data.Models; 
using StudentManagement.Data.ViewModels;
using System.Threading.Tasks;

namespace StudentManagement.Data.Services
{
    public class MarkService
    {
        private AppDbContext _context;
        private readonly ILogger<MarkService> _logger;
        public MarkService(AppDbContext context,ILogger<MarkService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public int TermCount(int termid,int studentid)
        {
            var termCount=_context.Marks.Where(x=>x.TermId==termid && x.StudentId==studentid).ToList();
            return termCount.Count();
        }

        public Mark AddMark(MarkVM mark)
        {
            _logger.LogInformation($"AddMark:MarkService", GetType().Name);
            try
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
                _logger.LogInformation($"Mark{_mark}");
                return _mark;
            }

            catch (Exception ex)
            {
                throw; 
            }                                                                                   
           
             
        }


        public Dictionary<string, Dictionary<string, int>> GetTotalMarks(int academicYear,int percentage)
        {
            _logger.LogInformation($"GetTotalMarks:MarkService", GetType().Name);
            try
            {
                var getTotal = _context.Marks.Where(x => x.Student.AcademicYear == academicYear).Select(g => new
                {

                    StudentName = g.Student.Name,
                    TermName = g.Term.TermName,
                    Percentage = (g.Tamil + g.English + g.Maths + g.Physics + g.Chemistry + g.ComputerScience) / 6

                }).Where(p => p.Percentage >= percentage).ToList();

                //return getTotal;

                Dictionary<string, Dictionary<string, int>> markStatus = new Dictionary<string, Dictionary<string, int>>();
                foreach (var student in getTotal)
                {
                    var studentDemo = markStatus.Where(s => s.Key == student.StudentName).FirstOrDefault();
                    if (studentDemo.Value == null)
                    {
                        markStatus.Add(student.StudentName, new Dictionary<string, int>()
                    {
                    {student.TermName,student.Percentage}

                    });
                    }
                    else
                    {
                        studentDemo.Value.Add(student.TermName, student.Percentage);

                    }

                }
                _logger.LogInformation($"Mark{markStatus}");
                return markStatus;
            } 
            catch (Exception ex) 
            {
                throw;

            }
            
        }

        public Dictionary<string,double> GetOverallTotalMarks(int academicYear,int percentage)
        {
            _logger.LogInformation($"GetOverallTotalMarks:MarkService", GetType().Name);
            try
            {

                var getTotal = _context.Marks.Where(x => x.Student.AcademicYear == academicYear).Select(n => new
                {
                    StudentName = n.Student.Name,
                    Percentage = (n.Tamil + n.English + n.Maths + n.Physics + n.Chemistry + n.ComputerScience) / 6
                });

                /*USING IF-ELSE CONDITION*/

                //Dictionary<string, Dictionary<string, double>> markStatus = new Dictionary<string, Dictionary<string, double>>();

                //foreach (var marks in getTotal)
                //{
                //    var tp = marks.Percentage;
                //    var studentDemo = markStatus.Where(s => s.Key == marks.StudentName).FirstOrDefault();
                //    if (studentDemo.Value == null)
                //    {

                //        markStatus.Add(marks.StudentName, new Dictionary<string, double>()
                //        {
                //            {"OverallPercentage",marks.Percentage }
                //        });
                //    }
                //    else
                //    {
                //        var overallmarks = 0.0;
                //        var overallPercentage = studentDemo.Value.TryGetValue("OverallPercentage", out overallmarks);
                //        overallmarks = overallmarks + marks.Percentage;
                //        studentDemo.Value.Remove("OverallPercentage");
                //        studentDemo.Value.Add("OverallPercentage", overallmarks);

                //    }

                //}
                //Dictionary<string, Dictionary<string, double>> FinalResult = new Dictionary<string, Dictionary<string, double>>();
                //foreach (KeyValuePair<string, Dictionary<string, double>> result in markStatus)
                //{
                //    var overallmarks = 0.0;
                //    var overallPercentage = result.Value.TryGetValue("OverallPercentage", out overallmarks);
                //    overallmarks = Math.Round(overallmarks / 6,1);

                //    if (overallmarks > 80)
                //    {
                //        FinalResult.Add(result.Key, new Dictionary<string, double>()
                //        {
                //            {"OverallPercentage",overallmarks }
                //        });

                //    }
                //}
                //return FinalResult;

                Dictionary<string, double> markStatus = new Dictionary<string, double>();
                foreach (var item in getTotal)
                {
                    var overall = 0.0;
                    markStatus.TryGetValue(item.StudentName, out overall);
                    markStatus.Remove(item.StudentName);
                    markStatus.Add(item.StudentName, overall = overall + item.Percentage);
                }
                Dictionary<string, double> FinalResult = new Dictionary<string, double>();
                foreach (KeyValuePair<string, double> result in markStatus)
                {
                    var overallmarks = 0.0;
                    markStatus.TryGetValue(result.Key, out overallmarks);
                    overallmarks = Math.Round(overallmarks / 6, 2);
                    if (overallmarks >= percentage)
                    {
                        FinalResult.Add(result.Key, overallmarks);
                    }

                }
                _logger.LogInformation($"Mark{FinalResult}");
                return FinalResult;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public Dictionary<string, Dictionary<string, int>> GetSubjectWiseMarks(int academicYear,string subject,int percentage)
        {
            _logger.LogInformation($"GetSubjectWiseMarks:MarkService", GetType().Name);
            try
            {
                var subjectMarks = _context.Marks.Where(x => x.Student.AcademicYear == academicYear).Select(m => new
                {
                    StudentName = m.Student.Name,
                    TermName = m.Term.TermName,
                    Marks = subject.Equals("Physics") ? m.Physics : subject.Equals("Chemistry") ? m.Chemistry : subject.Equals("ComputerScience") ? m.ComputerScience :
                    subject.Equals("English") ? m.English : subject.Equals("Tamil") ? m.Tamil : m.Maths

                }).Where(x => x.Marks >= percentage).ToList();
                Dictionary<string, Dictionary<string, int>> markList = new Dictionary<string, Dictionary<string, int>>();
                foreach (var mark in subjectMarks)
                {
                    var marks = markList.Where(x => x.Key == mark.StudentName).FirstOrDefault();
                    if (marks.Value == null)
                    {
                        markList.Add(mark.StudentName, new Dictionary<string, int>
                    {
                        {mark.TermName, mark.Marks}

                    });
                    }
                    else
                    {
                        marks.Value.Add(mark.TermName, mark.Marks);
                    }
                }
                _logger.LogInformation($"Mark{markList}");
                return markList;
            }
            catch(Exception ex)
            {
                throw;
            }
        }   
        
        public Dictionary<string,double> GetSubjectWiseOverAllPercentage(int academicYear,string subject,int percentage)
        {
            _logger.LogInformation($"GetSubjectWiseOverAllPercentage:MarkService", GetType().Name);
            try
            {
                var subjectMarks = _context.Marks.Where(x => x.Student.AcademicYear == academicYear).Select(m => new
                {
                    StudentName = m.Student.Name,
                    Marks = subject.Equals("Physics") ? m.Physics : subject.Equals("Chemistry") ? m.Chemistry : subject.Equals("ComputerScience") ? m.ComputerScience :
                    subject.Equals("English") ? m.English : subject.Equals("Tamil") ? m.Tamil : m.Maths
                });

                /*USING IF-ELSE CONDITION*/

                //Dictionary<string, Dictionary<string, double>> overallMarkList = new Dictionary<string, Dictionary<string, double>>();
                //foreach(var marklist in subjectMarks)
                //{
                //    var list = marklist.Marks;
                //    var result = overallMarkList.Where(s => s.Key == marklist.StudentName).FirstOrDefault();
                //    if (result.Value == null)
                //    {

                //        overallMarkList.Add(marklist.StudentName, new Dictionary<string, double>()
                //        {
                //            {"SubjectWiseOverallPercentage",marklist.Marks }
                //        });
                //    }
                //    else
                //    {
                //        var overallmarks = 0.0;
                //        var subjectWiseOverallPercentage = result.Value.TryGetValue("SubjectWiseOverallPercentage", out overallmarks);
                //        overallmarks = overallmarks + marklist.Marks;
                //        result.Value.Remove("SubjectWiseOverallPercentage");
                //        result.Value.Add("SubjectWiseOverallPercentage", overallmarks);
                //    }
                //}
                //Dictionary<string, Dictionary<string, double>> FinalResult = new Dictionary<string, Dictionary<string, double>>();
                //foreach (KeyValuePair<string, Dictionary<string, double>> result in overallMarkList)
                //{
                //    var overallmarks = 0.0;
                //    var subjectWiseOverallPercentage = result.Value.TryGetValue("SubjectWiseOverallPercentage", out overallmarks);
                //    overallmarks = Math.Round(overallmarks / 6,1);

                //    if (overallmarks>=80)
                //    {
                //        FinalResult.Add(result.Key, new Dictionary<string, double>()
                //        {
                //            {"SubjectWiseOverallPercentage",overallmarks }
                //        });

                //    }
                //}
                //return FinalResult;

                Dictionary<string, double> markStatus = new Dictionary<string, double>();
                foreach (var item in subjectMarks)
                {
                    var subjectwiseOverall = 0.0;
                    markStatus.TryGetValue(item.StudentName, out subjectwiseOverall);
                    markStatus.Remove(item.StudentName);
                    markStatus.Add(item.StudentName, subjectwiseOverall = subjectwiseOverall + item.Marks);
                }
                Dictionary<string, double> FinalResults = new Dictionary<string, double>();
                foreach (KeyValuePair<string, double> result in markStatus)
                {
                    var overallmarks = 0.0;
                    markStatus.TryGetValue(result.Key, out overallmarks);
                    overallmarks = Math.Round(overallmarks / 6, 2);
                    if (overallmarks >= percentage)
                    {
                        FinalResults.Add(result.Key, overallmarks);
                    }

                }
                _logger.LogInformation($"Mark{FinalResults}");
                return FinalResults;
            }
            catch (Exception ex)
            {
                throw; 
            }

        }
    }

    

}







