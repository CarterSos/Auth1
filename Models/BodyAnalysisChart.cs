using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Auth1.Models
{
    public partial class BodyAnalysisChart
    {
        [Key]
        public int? Squarenorthsouth { get; set; }
        public string Northsouth { get; set; }
        public int? Squareeastwest { get; set; }
        public string Eastwest { get; set; }
        public string Area { get; set; }
        public int? Burialnumber { get; set; }
        public DateTime? Dateofexamination { get; set; }
        public int? Preservationindex { get; set; }
        public string Haircolor { get; set; }
        public string Observations { get; set; }
        public string Robust { get; set; }
        public string Supraorbitalridges { get; set; }
        public string Orbitedge { get; set; }
        public string Parietalbossing { get; set; }
        public string Gonion { get; set; }
        public string Nuchalcrest { get; set; }
        public string Zygomaticcrest { get; set; }
        public string Sphenooccipitalsynchrondrosis { get; set; }
        public string Lamboidsuture { get; set; }
        public string Squamossuture { get; set; }
        public string Toothattrition { get; set; }
        public string Tootheruption { get; set; }
        public string Tootheruptionageestimate { get; set; }
        public string Ventralarc { get; set; }
        public string Subpubicangle { get; set; }
        public string Sciaticnotch { get; set; }
        public string Pubicbone { get; set; }
        public bool? Preauricularsulcus { get; set; }
        public string MedialIpRamus { get; set; }
        public bool? Dorsalpitting { get; set; }
        public string Femur { get; set; }
        public string Humerus { get; set; }
        public decimal? Femurheaddiameter { get; set; }
        public decimal? Humerusheaddiameter { get; set; }
        public decimal? Femurlength { get; set; }
        public decimal? Humeruslength { get; set; }
        public decimal? Estimatestature { get; set; }
        public string Osteophytosis { get; set; }
        public string CariesPeriodontalDisease { get; set; }
        public string Notes { get; set; }
        public ICollection<BurialmainBodyanalysischart> burialmain_bodyanalysischart { get; set; }
    }

    public partial class BurialmainBodyanalysischart
    {
        [Key]
        [Column(Order = 0)]
        public long MainBurialmainid { get; set; }
        public Burial burialmain { get; set; }
        [Key]
        [Column(Order = 1)]
        public long MainBodyanalysischartid { get; set; }
        public BodyAnalysisChart bodyanalysischart { get; set; }
    }
}
