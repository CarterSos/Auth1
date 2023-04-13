using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth1.Models
{
    public interface IMummyRepository
    {
        IQueryable<Masterburialsummary3> masterburialsummary3 { get; }
        IQueryable<Burial> burialmain { get; }
        IQueryable<Textile> textile { get; }

        // Used for Edit and Delete Actions
        IEnumerable<Masterburialsummary3> GetAllMummies();
        Masterburialsummary3 GetMummyById(long? id);
        void AddMummy(Masterburialsummary3 mummy);
        void UpdateMummy(Masterburialsummary3 mummy);
        void DeleteMummy(Masterburialsummary3 mummy);
        bool MummyExists(long? id);
        void Save();
    }
}
