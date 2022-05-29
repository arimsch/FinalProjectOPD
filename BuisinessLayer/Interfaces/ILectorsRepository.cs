using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLayer.Interfaces
{
    public interface ILectorsRepository
    {
        IEnumerable<Lector> GetAllLectors();
        Lector GetLectorById(int lectorId);
        void SaveLector(Lector lector);
        void DeleteLector(Lector lector);
        void CreateLector(Lector lector);
        void EditLectorPost(Lector lector);
        Lector EditLectorGet(int lectorId);
    }
}
