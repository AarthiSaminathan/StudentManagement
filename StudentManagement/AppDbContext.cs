using Microsoft.EntityFrameworkCore;
using StudentManagement.Data.Models;
using StudentManagement.Menu;

namespace StudentManagement
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions dbContextOption) : base(dbContextOption) 
        {
            
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<StudentTerm>()
        //        .HasKey(st => new { st.StudentId, st.TermId });
        //    modelBuilder.Entity<StudentTerm>()
        //        .HasOne(st => st.Student)
        //        .WithMany(s => s.StudentTerms)
        //        .HasForeignKey(st => st.StudentId);

        //    modelBuilder.Entity<StudentTerm>()
        //        .HasOne(st=> st.Term)
        //        .WithMany(t=>t.StudentTerms)
        //        .HasForeignKey(st=>st.TermId);

        //    modelBuilder.Entity<TermMark>()
        //         .HasKey(tm => new { tm.TermId,tm.MarkId });
        //    modelBuilder.Entity<TermMark>()
        //        .HasOne(st => st.Term)
        //        .WithMany(s => s.TermMarks)
        //        .HasForeignKey(st => st.TermId);

        //    modelBuilder.Entity<TermMark>()
        //        .HasOne(tm => tm.Mark)
        //        .WithMany(m => m.TermMarks)
        //        .HasForeignKey(tm => tm.MarkId);





        //}
        public DbSet<Student> Students { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<AdminDashboard> AdminDashboards { get; set; }
        public DbSet<Submenu> Submenus { get; set; }
        public DbSet<Menu_Submenu> Menu_Submenus { get; set; }
        public DbSet<FileValidation> FileValidation { get; set; }
        public DbSet<MenuDashboard> MenuDashboard { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu_Submenu>()
                .HasOne(m => m.AdminDashboard)
                .WithMany(sm => sm.Menu_Submenus)
                .HasForeignKey(m => m.AdmindashboardId);

            modelBuilder.Entity<Menu_Submenu>()
                .HasOne(m => m.Submenu)
                .WithMany(sm => sm.Menu_Submenus)
                .HasForeignKey(m => m.SubmenuId);
        }

    }
}
