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
    public class EFLectorsRepository : ILectorsRepository
    {
        private EFDBContext context;
        public EFLectorsRepository(EFDBContext context)
        {
            this.context = context;
        }

        public void DeleteLector(Lector lector)
        {
            context.Lectors.Remove(lector);
            context.SaveChanges();
        }

        public IEnumerable<Lector> GetAllLectors()
        {
            return context.Lectors.ToList();
        }

        public Lector GetLectorById(int lectorId)
        {
            return context.Lectors.FirstOrDefault(x => x.Id == lectorId);
        }

        public void SaveLector(Lector lector)
        {
            if (lector.Id == 0)
                context.Lectors.Add(lector);
            else
                context.Entry(lector).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void CreateLector(Lector lector)
        {
            context.Lectors.Add(lector);
            context.SaveChanges();
        }

        public void EditLectorPost(Lector lector)
        {
            context.Lectors.Update(lector);
            context.SaveChanges();
        }
        public Lector EditLectorGet(int lectorId)
        {
            return context.Lectors.FirstOrDefault(x => x.Id == lectorId);
        }
    }
}
