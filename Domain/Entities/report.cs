namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.report")]
    public partial class report
    {
        public long id { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? nature { get; set; }

        public long price { get; set; }

        public int? state { get; set; }

        public long? id_M_id { get; set; }

        public virtual mission mission { get; set; }
    }
}
