namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.task")]
    public partial class task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public task()
        {
            assignments = new HashSet<assignment>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public int duration { get; set; }

        [StringLength(255)]
        public string spec { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        public int? project_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<assignment> assignments { get; set; }

        public virtual project project { get; set; }
    }
}
