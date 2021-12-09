using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ligtasUnaAPI.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string User_Type { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string User_Fname { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string User_Lname { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string User_Address { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string User_ConNum { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Username { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Secret { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Ogranization { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Token { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Status { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Location_Long { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Location_Lat { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime User_CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime User_UpdatedAt { get; set; }
    }
}
