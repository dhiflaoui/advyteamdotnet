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
        public int id { get; set; }

        public DateTime? DATE_EVAL { get; set; }

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
        public virtual ICollection<Reclamation> reclamations { get; set; }
    }
}
