using BuisinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using DataLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLayer.Implementations
{
    public class EFStudentsRepository : IStudentsRepository
    {
        private EFDBContext context;
        public EFStudentsRepository(EFDBContext context)
        {
            this.context = context;
        }

        public void DeleteStudent(Student student)
        {
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public StudGrades GetAllStudents()
        {
            var students = context.Students.ToList();
            var attends = context.Attendances.ToList();
            StudGrades std = new StudGrades { Students = students, Attendances = attends };
            return std;
        }
        public IEnumerable<Student> GetStudents()
        {
            return context.Students.ToList();
        }
        public Student GetStudentById(int studentId)
        {
            return context.Students.FirstOrDefault(x => x.Id == studentId);
        }

        public void SaveStudent(Student student)
        {
            if (student.Id == 0)
                context.Students.Add(student);
            else
                context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void CreateStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void EditStudentPost(Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();
        }
        public Student EditStudentGet(int studentId)
        {
            return context.Students.FirstOrDefault(x => x.Id == studentId);
        }
    }
}
