using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModels
{
    public class StudGrades
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Attendance> Attendances { get; set; }

    }
}
