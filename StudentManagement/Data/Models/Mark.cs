﻿using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Data.Models
{
    public class Mark
    {
        
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TermId { get; set; }
        public int Tamil { get; set; }
        public int English { get; set; }
        public int Maths { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int ComputerScience { get; set; }


        public Student Student { get; set; }
       public Term Term { get; set; }

       
    }
}
