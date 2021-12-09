using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ligtasUnaAPI.Models
{
    public class Image
    {
        [Key]
        public int FaidPR_ImgID { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string FaidPR_ImgName { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string FaidPR_ImgUrl { get; set; }

        [ForeignKey("FaidPR_ID")]
        public virtual Firstaid Firstaids { get; set; }
    }
}
