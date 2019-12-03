namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            absences = new HashSet<absence>();
            affectations = new HashSet<affectation>();
            assignments = new HashSet<assignment>();
            conges = new HashSet<conge>();
            equipes = new HashSet<equipe>();
            evaluations = new HashSet<evaluation>();
            formations = new HashSet<formation>();
            missions = new HashSet<mission>();
            projects = new HashSet<project>();
           publications = new HashSet<publication>();
            feedbacks = new HashSet<feedback>();
            reactps = new HashSet<reactp>();




        }
        public user(String cin)
        {
            this.cin = cin;
        }
      


        public int id { get; set; }

        [Column(TypeName = "bit")]
        public bool? ToBeEval { get; set; }

        [StringLength(255)]
        public string adresseMail { get; set; }

        [StringLength(255)]
        public string cin { get; set; }

        [StringLength(255)]
        public string cv { get; set; }

        [StringLength(255)]
        public string motdp { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        [StringLength(255)]
        public string photo { get; set; }

        [StringLength(255)]
        public string prenom { get; set; }

        [StringLength(255)]
        public string role { get; set; }
        [StringLength(255)]
        public string badge { get; set; }

        public double? salaire { get; set; }

        public int? solde_absence { get; set; }

        public int? solde_conge { get; set; }

        [StringLength(255)]
        public string specialite { get; set; }

        [StringLength(255)]
        public string tel { get; set; }

        [StringLength(255)]
        public string ville { get; set; }

        public int? memberOf_id { get; set; }

        public long? mission_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<absence> absences { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<affectation> affectations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<assignment> assignments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<conge> conges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<equipe> equipes { get; set; }

        public virtual equipe equipe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<evaluation> evaluations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<formation> formations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mission> missions { get; set; }

        public virtual mission mission { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project> projects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<publication> publications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<feedback> feedbacks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reactp> reactps { get; set; }


    }
}
