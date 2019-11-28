namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public partial class formation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public formation()
        {
            affectations = new HashSet<affectation>();
        }

        public int Id { get; set; }

        [StringLength(255)]
        public string Titre { get; set; }

        [StringLength(255)]
        public string date { get; set; }

        public int? duree { get; set; }

        public int? nbrP { get; set; }

        [StringLength(255)]
        public string objectifs { get; set; }

        public int? prix { get; set; }

        [StringLength(255)]
        public string Specialtie { get; set; }

        public int? formateur_id { get; set; }

        public int? user_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<affectation> affectations { get; set; }

        public virtual formateur formateur { get; set; }

        public virtual user user { get; set; }
    }
}
