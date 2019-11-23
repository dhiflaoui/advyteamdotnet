namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.bug")]
    public partial class bug
    {
        public int id { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? reportDate { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        public int? project_id { get; set; }

        public virtual project project { get; set; }
    }
}
