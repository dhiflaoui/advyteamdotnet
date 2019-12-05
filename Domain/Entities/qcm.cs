namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.qcm")]
    public partial class qcm
    {
        public int qcmId { get; set; }

        [StringLength(255)]
        public string COP { get; set; }

        [StringLength(255)]
        public string OPA { get; set; }

        [StringLength(255)]
        public string OPB { get; set; }

        [StringLength(255)]
        public string OPC { get; set; }

        [StringLength(255)]
        public string OPD { get; set; }

        [StringLength(255)]
        public string Qtext { get; set; }

        public int? Specialite { get; set; }

        public int? formationEnLigne_formationElLigneId { get; set; }

        public virtual formationenligne formationenligne { get; set; }
    }
}
