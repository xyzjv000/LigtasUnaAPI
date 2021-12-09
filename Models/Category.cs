using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ligtasUnaAPI.Models
{
    public class Category
    {
        [Key]
        public int Cat_ID { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Cat_Name { get; set; }

        [ForeignKey("FaidPR_ID")]
        public virtual Firstaid Firstaids { get; set; }
    }
}
