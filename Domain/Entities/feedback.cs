using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("pidev.feedback")]

    public class feedback
    {
        public int id { get; set; }

        [StringLength(255)]
        public string comment { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(255)]
        public string file { get; set; }

        public int? publication_id { get; set; }

        public virtual publication publication { get; set; }

        public int? user_id { get; set; }

        public virtual user user { get; set; }
    }
}
