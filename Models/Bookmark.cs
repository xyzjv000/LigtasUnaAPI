using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ligtasUnaAPI.Models
{
    public class Bookmark
    {
        [Key]
        public int Bookmark_ID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Bookmark_date { get; set; }

        [ForeignKey("User_ID")]
        public virtual User Users { get; set; }

        [ForeignKey("FaidPR_ID")]
        public virtual Firstaid Firstaids { get; set; }
    }
}
