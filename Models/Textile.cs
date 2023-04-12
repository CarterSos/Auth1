using Auth1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Auth1.Models.Burial;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Auth1.Models
{
    public partial class Textile
    {
        public long id { get; set; }
        public string locale { get; set; }
        public int? textileid { get; set; }
        public string description { get; set; }
        public string burialnumber { get; set; }
        public string estimatedperiod { get; set; }
        public DateTime? sampledate { get; set; }
        public DateTime? photographeddate { get; set; }
        public string direction { get; set; }

        public ICollection<BurialmainTextile> burialmain_textile { get; set; }
        public ICollection<ColorTextile> color_textile { get; set; }
        public ICollection<StructureTextile> structure_textile { get; set; }
        public ICollection<TextilefunctionTextile> textilefunction_textile { get; set; }
    }

    public partial class ColorTextile
    {
        [Key]
        [Column(Order = 0)]
        public long maincolorid { get; set; }
        public Color color { get; set; }
        [Key]
        [Column(Order = 1)]
        public long maintextileid { get; set; }
        public Textile textile { get; set; }
    }

    public partial class Color
    {
        public long id { get; set; }
        public string value { get; set; }
        public int? colorid { get; set; }
        public ICollection<ColorTextile> color_textile { get; set; }
    }
    public partial class StructureTextile
    {
        [Key]
        [Column(Order = 0)]
        public long mainstructureid { get; set; }
        public Structure structure { get; set; }
        [Key]
        [Column(Order = 1)]
        public long maintextileid { get; set; }
        public Textile textile { get; set; }
    }

    public partial class Structure
    {
        public long id { get; set; }
        public string value { get; set; }
        public int? structureid { get; set; }
        public ICollection<StructureTextile> structure_textile { get; set; }
    }

    public partial class TextilefunctionTextile
    {
        [Key]
        [Column(Order = 0)]
        public long maintextilefunctionid { get; set; }
        public Textilefunction textilefunction { get; set; }
        [Key]
        [Column(Order = 1)]
        public long maintextileid { get; set; }
        public Textile textile { get; set; }
}

    public partial class Textilefunction
    {
        public long id { get; set; }
        public string value { get; set; }
        public int? textilefunctionid { get; set; }
        public ICollection<TextilefunctionTextile> textilefunction_textile { get; set; }
    }

    
}
