namespace ConsoleApp1.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TechnetModelloCF : DbContext
    {
        public TechnetModelloCF()
            : base("name=TechnetModelloCF")
        {
        }

        public virtual DbSet<Articoli> Articolis { get; set; }
        public virtual DbSet<Famiglie> Famiglies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Famiglie>()
                .HasMany(e => e.Articolis)
                .WithRequired(e => e.Famiglie)
                .WillCascadeOnDelete(false);
        }
    }
}
