using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Models
{
    [Table("calls")]
    public class ImmigrationCalls
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]

        [Column("id")]
        public string id { get; set; }

        [Column("date_start")]
        public string date_start { get; set; }

                
}
}
