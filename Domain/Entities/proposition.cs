namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.proposition")]
    public partial class proposition
    {
        [Key]
        public int ProposID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateprop { get; set; }

        [StringLength(255)]
        public string descprop { get; set; }

        [StringLength(255)]
        public string fichier { get; set; }

        [StringLength(255)]
        public string titreprop { get; set; }

        public int? user_id { get; set; }

        public virtual user user { get; set; }
    }
}
