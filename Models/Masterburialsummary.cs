using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Auth1.Models
{
    public partial class Masterburialsummary
    {
        public long? id { get; set; }
        public string? burialid { get; set; }
        public string sex { get; set; }
        public string ageatdeath { get; set; }
        public string headdirection { get; set; }
        public string haircolor { get; set; }
        public string depth { get; set; }
        public string color { get; set; }
        public string structure { get; set; }
        public int? estimatestature { get; set; }
        public string textilefunction { get; set; }
        public string textiledescription { get; set; }
        public string burialtext { get; set; }
        public string length { get; set; }
        public string goods { get; set; }
        public string facebundles { get; set; }
        public DateTime? dateofexcavation { get; set; }
        public string photodescription { get; set; }
        public string photofilename { get; set; }
        public string photourl { get; set; }
        public string textiledimensiontype { get; set; }
        public string textiledimensionvalue { get; set; }
    }
}
