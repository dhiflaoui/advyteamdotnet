namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.publication")]
    public partial class publication
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(255)]
        public string file { get; set; }

        [StringLength(255)]
        public string statut { get; set; }

        public int? user_id { get; set; }

        public virtual user user { get; set; }
    }
}
