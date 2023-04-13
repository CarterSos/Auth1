using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth1.Models
{
    public class EFMummyRepository : IMummyRepository
    {
        private MummyContext context { get; set; }

        public EFMummyRepository (MummyContext temp)
        {
            context = temp;
        }
        public IQueryable<Masterburialsummary3> masterburialsummary3 => context.masterburialsummary3;

        public IQueryable<Burial> burialmain => context.burialmain;
        public IQueryable<Textile> textile => context.textile;


        public IEnumerable<Masterburialsummary3> GetAllMummies()
        {
            return context.masterburialsummary3.ToList();
        }

        public Masterburialsummary3 GetMummyById(long? id)
        {
            return context.masterburialsummary3.FirstOrDefault(m => m.id == id);
        }

        public void AddMummy(Masterburialsummary3 mummy)
        {
            context.masterburialsummary3.Add(mummy);
        }

        public void UpdateMummy(Masterburialsummary3 mummy)
        {
            context.Entry(mummy).State = EntityState.Modified;
        }

        public void DeleteMummy(Masterburialsummary3 mummy)
        {
            context.masterburialsummary3.Remove(mummy);
        }

        public bool MummyExists(long? id)
        {
            return context.masterburialsummary3.Any(m => m.id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
