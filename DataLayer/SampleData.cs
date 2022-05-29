using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    //Заполнение бд, если в ней отсутствуют данные
    public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if (!context.Students.Any())
            {
                context.Students.Add(new Entityes.Student() { Name = "Даша" });
                context.SaveChanges();
            }

            if (!context.Lectors.Any())
            {
                context.Lectors.Add(new Entityes.Lector() { Name = "Арина" });
                context.SaveChanges();
            }

          

            
        }
    }
}
