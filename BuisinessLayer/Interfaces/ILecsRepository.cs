using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLayer.Interfaces
{
    public interface ILecsRepository
    {
        IEnumerable<Lec> GetAllLecs();
        Lec GetLecById(int lecId);
        void SaveLec(Lec lec);
        void DeleteLec(Lec lec);
        void CreateLec(Lec lec);
        void EditLecPost(Lec lec);
        Lec EditLecGet(int lecId);
        void SaveXML(Lec lec);
        void SaveJSON(Lec lec);
    }
}
