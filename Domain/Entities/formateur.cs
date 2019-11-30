namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.formateur")]
    public partial class formateur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public formateur()
        {
            formations = new HashSet<formation>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string Disponible { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        [StringLength(255)]
        public string numero { get; set; }

        [StringLength(255)]
        public string prenom { get; set; }

        [StringLength(255)]
        public string Specialite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<formation> formations { get; set; }
    }
}
