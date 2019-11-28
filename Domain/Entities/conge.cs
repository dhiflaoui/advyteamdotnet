namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public partial class conge
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateDebut { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateFin { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        [StringLength(255)]
        public string file { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int? user_id { get; set; }

        public virtual user user { get; set; }
    }
}
