using Mysqlx.Datatypes;
using StudentManagement.Data.Models;
using StudentManagement.Data.ViewModels;
using System.Net.WebSockets;

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
                Tamil = mark.Tamil,
                English = mark.English,
                Maths = mark.Maths,
                Physics = mark.Physics,
                Chemistry = mark.Chemistry,
                ComputerScience = mark.ComputerScience
                
               
                
            };
            _context.Marks.Add(_mark);
            _context.SaveChangesAsync();
            foreach (var id in mark.TermId)
            {
                var _TermMark = new TermMark()
                {
                    MarkId=mark.Id,
                    TermId=id
                };
                _context.TermMarks.Add(_TermMark);
                _context.SaveChanges();
            }
        }
        public double GetTotalMarks( )
        {
            var Sum = _context.Marks.Select(x => x.Tamil + x.English + x.Maths + x.Physics + x.Chemistry + x.ComputerScience).Sum()/6;


           
            return Sum;



            //var Sum= _context.Marks.Select(x=>x.Tamil+x.English+x.Maths+x.Physics+x.Chemistry+x.ComputerScience).Average();
            // var percentage = Sum / 6;
            // if(percentage > 80)
            // {
            //     var  Demo=  _context.StudentTerms.Select(s => s.Student.Name);
            //     _context.SaveChanges();

            // }
            // return Demo;

        }
    }
}

