using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth1.Models.ViewModels
{
    public class FieldsViewModel
    {
        public IEnumerable<string> BurialID { get; set; }
        public IEnumerable<string> Sex { get; set; }
        public IEnumerable<string> Area { get; set; }
        public IEnumerable<string> AgeAtDeath { get; set; }
        public IEnumerable<string> HeadDirection { get; set; } 
        public IEnumerable<string> HairColor { get; set; } 
        public IEnumerable<string> TextileColor { get; set; } 
        public IEnumerable<string> TextileStructure { get; set; }
        public IEnumerable<string> TextileFunction { get; set; }
        public IEnumerable<float> EstimateStature { get; set; }        
        public IEnumerable<string> Femur { get; set; }


    }
}
