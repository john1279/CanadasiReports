using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Models
{
    [Table("leads")]
    public class ImmigrationLeads
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]

        [Column("first_name")]
        public string first_name { get; set; }


        [Column("department")]
        public Guid department { get; set; }

        [Column("status")]
        public Guid status { get; set; }

        [Column("date_entered")]
        public string date_entered { get; set; }

        [Column("lead_source_description")]
        public Guid lead_source_description { get; set; }

        [Column("status_description")]
        public string status_descriptiond { get; set; }
    }
}
