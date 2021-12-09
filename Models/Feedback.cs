using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ligtasUnaAPI.Models
{
    public class Feedback
    {
        [Key]
        public int Feed_ID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Feed_Descrp { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Feed_Date { get; set; }

        [ForeignKey("User_ID")]
        public virtual User Users { get; set; }

        [ForeignKey("FaidPR_ID")]
        public virtual Firstaid Firstaids { get; set; }
    }
}
