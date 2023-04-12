using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth1.Models.ViewModels
{
    public class FieldsViewModel
    {
        public IEnumerable<string> Sex { get; set; }
        public string thisSex { get; set; }
        public IEnumerable<string> TextileColor { get; set; }
        public string thisTextileColor { get; set; }
    }
}
