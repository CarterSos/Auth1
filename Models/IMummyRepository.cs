using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth1.Models
{
    public interface IMummyRepository
    {
        IQueryable<Masterburialsummary> masterburialsummary { get; }
        IQueryable<Burial> burialmain { get; }
        IQueryable<Textile> textile { get; }

        // Used for Edit and Delete Actions
        IEnumerable<Masterburialsummary> GetAllMummies();
        Masterburialsummary GetMummyById(long? id);
        void AddMummy(Masterburialsummary mummy);
        void UpdateMummy(Masterburialsummary mummy);
        void DeleteMummy(Masterburialsummary mummy);
        bool MummyExists(long? id);
        void Save();
    }
}
