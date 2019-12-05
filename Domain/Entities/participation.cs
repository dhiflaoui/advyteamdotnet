namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.participation")]
    public partial class participation
    {
        [Key]
        public int idParticpant { get; set; }

        public DateTime created { get; set; }

        public DateTime updated { get; set; }

        public DateTime? dateParticipation { get; set; }

        public int? idMission { get; set; }

        public int? idUser { get; set; }

        [StringLength(255)]
        public string etat { get; set; }
    }
}
