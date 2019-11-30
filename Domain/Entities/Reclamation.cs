namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.reclamation")]
    public partial class reclamation
    {
        [Key]
        public int ReclmationID { get; set; }

        [StringLength(255)]
        public string comment { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateclose { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateopen { get; set; }

        [StringLength(255)]
        public string descp { get; set; }

        [StringLength(255)]
        public string fich { get; set; }

        [StringLength(255)]
        public string reponse { get; set; }

        public int? statut { get; set; }

        [StringLength(255)]
        public string titreclaim { get; set; }

        public int? evaluation_id { get; set; }

        public int? user_id { get; set; }

        public virtual evaluation evaluation { get; set; }

        public virtual user user { get; set; }
    }
}
