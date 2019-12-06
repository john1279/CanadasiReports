using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Models
{
    [Table("accounts")]
    public class ImmigrationLeads
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        [Column("'date_entered'")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
