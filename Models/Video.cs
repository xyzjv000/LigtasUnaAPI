using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ligtasUnaAPI.Models
{
    public class Video
    {
        [Key]
        public int FaidPR_VidID { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string FaidPR_VidName { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string FaidPR_VidUrl { get; set; }

        [ForeignKey("FaidPR_ID")]
        public virtual Firstaid Firstaids { get; set; }
    }
}
