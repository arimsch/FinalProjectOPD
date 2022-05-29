using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLayer.Interfaces
{
    public interface IAttendancesRepository
    {
        IEnumerable<Attendance> GetAllAttendancesGet(Lec lect);
        void GetAllAttendancesPost(Attendance attendance);
        void SaveAttendance(Attendance attendance);
        void DeleteAttendance(Attendance attendance);
        Attendance EditAttendanceGet(int attendanceId);
        void EditAttendancePost(Attendance attendance);
    }
}
