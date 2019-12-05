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
            affectationenligne = new HashSet<affectationenligne>();
            formationenligne = new HashSet<formationenligne>();
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
        public virtual ICollection<affectationenligne> affectationenligne { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<formationenligne> formationenligne { get; set; }
    }
}
