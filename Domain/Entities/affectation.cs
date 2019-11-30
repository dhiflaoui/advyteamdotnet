namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.affectation")]
    public partial class affectation
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Montion { get; set; }

        public int? Score { get; set; }

        public int? formations_Id { get; set; }

        public int? users_id { get; set; }

        public virtual user user { get; set; }

        public virtual formation formation { get; set; }
    }
}
