namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.formationenligne")]
    public partial class formationenligne
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public formationenligne()
        {
            affectationenligne = new HashSet<affectationenligne>();
            cours = new HashSet<cours>();
            qcm = new HashSet<qcm>();
        }

        [Key]
        public int formationElLigneId { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [StringLength(255)]
        public string objectifs { get; set; }

        [StringLength(255)]
        public string titre { get; set; }

        public int? formateur_id { get; set; }

        public int? user_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<affectationenligne> affectationenligne { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cours> cours { get; set; }

        public virtual formateur formateur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<qcm> qcm { get; set; }

        public virtual user user { get; set; }
    }
}
