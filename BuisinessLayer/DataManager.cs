using BuisinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLayer
{
    public class DataManager
    {
        private IStudentsRepository _studentsRep;
        private ILectorsRepository _lectorsRep;
        private ILecsRepository _lecsRep;
        private IAttendancesRepository _attendancesRep;

        public DataManager(IStudentsRepository studentsRep, ILectorsRepository lectorsRep, ILecsRepository lecsRep, IAttendancesRepository attendancesRep)
        {
            _studentsRep = studentsRep;
            _lectorsRep = lectorsRep;
            _lecsRep = lecsRep;
            _attendancesRep = attendancesRep;
        }
        public IStudentsRepository StudentsRep { get { return _studentsRep; } }
        public ILectorsRepository LectorsRep { get { return _lectorsRep; } }
        public ILecsRepository LecsRep { get { return _lecsRep; } }
        public IAttendancesRepository AttendancesRep { get { return _attendancesRep; } }
    }
}
