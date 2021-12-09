using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ligtasUnaAPI.Models
{
    public class Subscription
    {
        [Key]
        public int Sub_ID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Sub_date { get; set; }

        [ForeignKey("User_ID")]
        public virtual User Users { get; set; }
    }
}
