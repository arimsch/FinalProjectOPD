using BuisinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLayer.Implementations
{
    public class EFAttendancesRepository : IAttendancesRepository
    {
        private EFDBContext context;
        public EFAttendancesRepository(EFDBContext context)
        {
            this.context = context;
        }

        public void DeleteAttendance(Attendance attendance)
        {
            context.Attendances.Remove(attendance);
            context.SaveChanges();
        }

        public IEnumerable<Attendance> GetAllAttendancesGet(Lec lect)
        {
            var att = context.Attendances.Where(x => x.LecId == lect.Id);
            List<Student> stud = context.Students.ToList();
            foreach(var s in stud)
            {
                
                if (!att.Where(x => x.StudentId == s.Id).Any())
                {
                    Attendance attend = new Attendance
                    {
                        LecId = lect.Id,
                        StudentId = s.Id,
                        Grade = 0,
                        Attend = false
                    };
                    context.Attendances.Add(attend);
                    context.SaveChanges();
                }
                else
                {

                }
            }
            return att;
        }

        public void GetAllAttendancesPost(Attendance attendance)
        {
          
            context.Attendances.Update(attendance);
            context.SaveChanges();

        }

        public void SaveAttendance(Attendance attendance)
        {
            if (attendance.Id == 0)
                context.Attendances.Add(attendance);
            else
                context.Entry(attendance).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public Attendance EditAttendanceGet(int attendanceId)
        {
            return context.Attendances.FirstOrDefault(p => p.Id == attendanceId);
        }
        public void EditAttendancePost(Attendance attendance)
        {
            context.Attendances.Update(attendance);
            context.SaveChanges();
            
        }
    }
}
