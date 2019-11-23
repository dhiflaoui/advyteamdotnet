namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.assignment")]
    public partial class assignment
    {
        public int id { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int finishedIn { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        public int? emp_id { get; set; }

        public int? task_id { get; set; }

        public virtual task task { get; set; }

        public virtual user user { get; set; }
    }
}
