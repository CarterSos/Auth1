using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth1.Models.ViewModels
{
    public class BurialViewModel
    {
        public IQueryable<Masterburialsummary> masterburialsummary { get; set; }
        public IQueryable<Burial> burialmain { get; set; }
        public IQueryable<Textile> textile { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
