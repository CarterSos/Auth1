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
        public IQueryable<Masterburialsummary> masterburialsummary => context.masterburialsummary;

        public IQueryable<Burial> burialmain => context.burialmain;
        public IQueryable<Textile> textile => context.textile;


        public IEnumerable<Masterburialsummary> GetAllMummies()
        {
            return context.masterburialsummary.ToList();
        }

        public Masterburialsummary GetMummyById(long? id)
        {
            return context.masterburialsummary.FirstOrDefault(m => m.id == id);
        }

        public void AddMummy(Masterburialsummary mummy)
        {
            context.masterburialsummary.Add(mummy);
        }

        public void UpdateMummy(Masterburialsummary mummy)
        {
            context.Entry(mummy).State = EntityState.Modified;
        }

        public void DeleteMummy(Masterburialsummary mummy)
        {
            context.masterburialsummary.Remove(mummy);
        }

        public bool MummyExists(long? id)
        {
            return context.masterburialsummary.Any(m => m.id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
