using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("pidev.reactp")]

   public  class reactp
    {
        public int id { get; set; }
        public int? publication_id { get; set; }

        public virtual publication publication { get; set; }

        public int? user_id { get; set; }

        public virtual user user { get; set; }
    }
}
