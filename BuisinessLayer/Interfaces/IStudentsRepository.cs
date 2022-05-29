using DataLayer.Entityes;
using DataLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLayer.Interfaces
{
    public interface IStudentsRepository
    {
        StudGrades GetAllStudents();
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int studentId);
        void SaveStudent(Student student);
        void DeleteStudent(Student student);
        void CreateStudent(Student student);
        void EditStudentPost(Student student);
        Student EditStudentGet(int studentId);
    }
}
