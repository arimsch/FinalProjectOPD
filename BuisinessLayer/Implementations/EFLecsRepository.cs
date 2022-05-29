using BuisinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuisinessLayer.Implementations
{
    public class EFLecsRepository : ILecsRepository
    {
        private EFDBContext context;
        public EFLecsRepository(EFDBContext context)
        {
            this.context = context;
        }
        public void DeleteLec(Lec lec)
        {
            context.Lecs.Remove(lec);
            context.SaveChanges();
        }

        public IEnumerable<Lec> GetAllLecs()
        {
            return context.Lecs.Include(a => a.Lector).ToList();
        }

        public Lec GetLecById(int lecId)
        {
            return context.Lecs.FirstOrDefault(x => x.Id == lecId);
        }

        public void SaveLec(Lec lec)
        {
            if (lec.Id == 0)
                context.Lecs.Add(lec);
            else
                context.Entry(lec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void CreateLec(Lec lec)
        {
            context.Lecs.Add(lec);
            context.SaveChanges();
        }

        public void EditLecPost(Lec lec)
        {
            context.Lecs.Update(lec);
            context.SaveChanges();
        }
        public Lec EditLecGet(int lecId)
        {
            return context.Lecs.FirstOrDefault(x => x.Id == lecId);
        }
        public void SaveXML(Lec lec)
        {
            string filename = "Attendance " + lec.Id + ".xml";
            var report = from a in context.Attendances
                         join st in context.Students on a.StudentId equals st.Id
                         join l in context.Lecs on a.LecId equals l.Id
                         select new { Subject = l.Subject, Date = l.Date, Student = st.Name, Attend = a.Attend, Grade = a.Grade };
            XElement x = new XElement("Attendance",
                                                  from r in report.ToList()
                                                  select new XElement("Lecture",
                                                         new XElement("Subject", r.Subject),
                                                         new XElement("Date", r.Date),
                                                         new XElement("Student",
                                                         new XElement("Name", r.Student),
                                                         new XElement("Attend", r.Attend),
                                                         new XElement("Grade", r.Grade))));
            string s = x.ToString();
            using (FileStream fs = System.IO.File.Create(filename))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(s);
                }
            }
        }

        public void SaveJSON(Lec lec)
        {
            string filename = "Attendance " + lec.Id + ".json";
            var report = from a in context.Attendances
                         join st in context.Students on a.StudentId equals st.Id
                         join l in context.Lecs on a.LecId equals l.Id
                         select new { Subject = l.Subject, Date = l.Date, Student = st.Name, Attend = a.Attend, Grade = a.Grade };
            string s = JsonConvert.SerializeObject(report, Formatting.Indented);
            using (FileStream fs = System.IO.File.Create(filename))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(s);
                }
            }
        }
    }
}
