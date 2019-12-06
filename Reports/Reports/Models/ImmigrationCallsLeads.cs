using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Models
{
    [Table("email_addr_bean_rel")]
    public class ImmigrationCallsLeads
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]

        [Column("call_id")]
        public string call_id { get; set; }


    }
}