using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using static Auth1.Models.Burial;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Auth1.Models
{
    public partial class MummyContext : DbContext
    {
        public MummyContext()
        {
        }

        public MummyContext(DbContextOptions<MummyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Burial> burialmain { get; set; }
        public virtual DbSet<Color> color { get; set; }
        public virtual DbSet<BurialmainTextile> burialmain_textile { get; set; }
        public virtual DbSet<ColorTextile> color_textile { get; set; }
        public virtual DbSet<Structure> structure { get; set; }
        public virtual DbSet<StructureTextile> structure_textile { get; set; }
        public virtual DbSet<Textilefunction> textilefunction { get; set; }
        public virtual DbSet<TextilefunctionTextile> textilefunction_textile { get; set; }
        public virtual DbSet<Textile> textile { get; set; }
        public virtual DbSet<BodyAnalysisChart> BodyAnalysisChart { get; set; }
        public virtual DbSet<BurialmainBodyanalysischart> BurialmainBodyanalysischart { get; set; }
        public virtual DbSet<Masterburialsummary3> masterburialsummary3 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the composite primary key using Fluent API
            modelBuilder.Entity<BurialmainBodyanalysischart>()
                .HasKey(bb => new { bb.MainBurialmainid, bb.MainBodyanalysischartid });
            modelBuilder.Entity<BurialmainTextile>()
                .HasKey(bt => new { bt.mainburialmainid, bt.maintextileid });
            modelBuilder.Entity<ColorTextile>()
                .HasKey(bt => new { bt.maincolorid, bt.maintextileid });
            modelBuilder.Entity<TextilefunctionTextile>()
                .HasKey(bt => new { bt.maintextilefunctionid, bt.maintextileid });
            modelBuilder.Entity<StructureTextile>()
                .HasKey(bt => new { bt.mainstructureid, bt.maintextileid });

        }
    }
}
