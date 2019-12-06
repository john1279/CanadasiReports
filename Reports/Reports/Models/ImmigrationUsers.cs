using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Models
{
    [Table("users")]
   
    public class ImmigrationUsers
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]

        [Column("user_name")]
        public string user_name { get; set; }


    }
}