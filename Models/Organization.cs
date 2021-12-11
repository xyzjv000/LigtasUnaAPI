using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ligtasUnaAPI.Models
{
    public class Organization
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Contact_Name { get; set; }
        
        
        [Column(TypeName = "varchar(20)")]
        public string Contact_Number { get; set; }

        [ForeignKey("User_ID")]
        public virtual User Users { get; set; }
    }
}
