namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain.Entities;
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class AdvyteamContext : DbContext
    {
        public AdvyteamContext()
            : base("AdvyteamContext")
        {
        }

        public virtual DbSet<absence> absences { get; set; }
        public virtual DbSet<affectation> affectations { get; set; }
        public virtual DbSet<assignment> assignments { get; set; }
        public virtual DbSet<bug> bugs { get; set; }
        public virtual DbSet<conge> conges { get; set; }
        public virtual DbSet<equipe> equipes { get; set; }
        public virtual DbSet<evaluation> evaluations { get; set; }
        public virtual DbSet<formateur> formateurs { get; set; }
        public virtual DbSet<formation> formations { get; set; }
        public virtual DbSet<mission> missions { get; set; }
        public virtual DbSet<project> projects { get; set; }
        public virtual DbSet<report> reports { get; set; }
        public virtual DbSet<task> tasks { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<Reclamation> Reclamations{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
