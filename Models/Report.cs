using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ligtasUnaAPI.Models
{
    public class Report
    {
        [Key]
        public int Report_ID { get; set; }
        [Column(TypeName = "BIT")]
        public bool Report_Subc { get; set; }
        [Column(TypeName = "BIT")]
        public bool Report_Feedback { get; set; }

        [Column(TypeName = "BIT")]
        public bool Active { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey("User_ID")]
        public virtual User Users { get; set; }

        public Report()
        {
            this.CreatedAt = DateTime.Now;
        }

    }
}
