namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public partial class mission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mission()
        {
            users = new HashSet<user>();
            reports = new HashSet<report>();
        }

        public long id { get; set; }

        public DateTime created { get; set; }

        public DateTime updated { get; set; }

        [StringLength(255)]
        public string dateEnd { get; set; }

        [StringLength(255)]
        public string dateStart { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string location { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string Specialite { get; set; }

        public int? assignee_id { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<report> reports { get; set; }
    }
}
