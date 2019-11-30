namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.evaluation")]
    public partial class evaluation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public evaluation()
        {
            reclamations = new HashSet<reclamation>();
        }

        public int id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime DATE_EVAL { get; set; }

        [StringLength(255)]
        public string Titre_Eval { get; set; }

        [StringLength(255)]
        public string Type { get; set; }

        [StringLength(255)]
        public string desc_Eval { get; set; }

        public int? score_Manager { get; set; }

        public int? score_self { get; set; }

        public int? score_team { get; set; }

        public int? user_id { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reclamation> reclamations { get; set; }
    }
}
