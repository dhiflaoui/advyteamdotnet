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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<absence>()
                .Property(e => e.decision)
                .IsUnicode(false);

            modelBuilder.Entity<absence>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<absence>()
                .Property(e => e.file)
                .IsUnicode(false);

            modelBuilder.Entity<affectation>()
                .Property(e => e.Montion)
                .IsUnicode(false);

            modelBuilder.Entity<assignment>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<assignment>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<bug>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<bug>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<bug>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<conge>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<conge>()
                .Property(e => e.file)
                .IsUnicode(false);

            modelBuilder.Entity<conge>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<equipe>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<equipe>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<equipe>()
                .HasMany(e => e.users)
                .WithOptional(e => e.equipe)
                .HasForeignKey(e => e.memberOf_id);

            modelBuilder.Entity<evaluation>()
                .Property(e => e.Titre_Eval)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation>()
                .Property(e => e.desc_Eval)
                .IsUnicode(false);

            modelBuilder.Entity<formateur>()
                .Property(e => e.Disponible)
                .IsUnicode(false);

            modelBuilder.Entity<formateur>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<formateur>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<formateur>()
                .Property(e => e.numero)
                .IsUnicode(false);

            modelBuilder.Entity<formateur>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<formateur>()
                .Property(e => e.Specialite)
                .IsUnicode(false);

            modelBuilder.Entity<formateur>()
                .HasMany(e => e.formations)
                .WithOptional(e => e.formateur)
                .HasForeignKey(e => e.formateur_id);

            modelBuilder.Entity<formation>()
                .Property(e => e.Titre)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.date)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.objectifs)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.Specialtie)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .HasMany(e => e.affectations)
                .WithOptional(e => e.formation)
                .HasForeignKey(e => e.formations_Id);

            modelBuilder.Entity<mission>()
                .Property(e => e.dateEnd)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.dateStart)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.Specialite)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .HasMany(e => e.users)
                .WithOptional(e => e.mission)
                .HasForeignKey(e => e.mission_id);

            modelBuilder.Entity<mission>()
                .HasMany(e => e.reports)
                .WithOptional(e => e.mission)
                .HasForeignKey(e => e.id_M_id);

            modelBuilder.Entity<project>()
                .Property(e => e.clientName)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .HasMany(e => e.bugs)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.project_id);

            modelBuilder.Entity<project>()
                .HasMany(e => e.tasks)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.project_id);

            modelBuilder.Entity<report>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<report>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<report>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.spec)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .HasMany(e => e.assignments)
                .WithOptional(e => e.task)
                .HasForeignKey(e => e.task_id);

            modelBuilder.Entity<user>()
                .Property(e => e.adresseMail)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.cin)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.cv)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.motdp)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.specialite)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.ville)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.absences)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.affectations)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.users_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.assignments)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.emp_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.conges)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.equipes)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.managedBy_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.evaluations)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.formations)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.missions)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.assignee_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.projects)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.ownedBy_id);
        }
    }
}
