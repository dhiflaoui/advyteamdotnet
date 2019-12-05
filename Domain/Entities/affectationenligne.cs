namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.affectationenligne")]
    public partial class affectationenligne
    {
        [Key]
        public int participationId { get; set; }

        public int? niveau { get; set; }

        public int? score { get; set; }

        public int? formationEnLigne_formationElLigneId { get; set; }

        public int? users_id { get; set; }

        public virtual user user { get; set; }

        public virtual formationenligne formationenligne { get; set; }
    }
}
