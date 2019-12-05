namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.cours")]
    public partial class cours
    {
        [Key]
        public int courId { get; set; }

        [StringLength(255)]
        public string cour { get; set; }

        [StringLength(255)]
        public string titre { get; set; }

        [StringLength(255)]
        public string video { get; set; }

        public int? formationEnLign_formationElLigneId { get; set; }

        public virtual formationenligne formationenligne { get; set; }
    }
}
