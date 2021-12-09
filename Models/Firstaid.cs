using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ligtasUnaAPI.Models
{
    public class Firstaid
    {
        [Key]
        public int FaidPR_ID { get; set; }
   
        [Column(TypeName = "varchar(255)")]
        public string FaidPR_Name { get; set; }

        [Column(TypeName = "integer")]
        public int Views { get; set; }
        
        [Column(TypeName = "nvarchar(max)")]
        public string Status { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string FaidPR_Des { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
    }
}
