using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Models
{
    [Table("TotalLeads")]
    public class TotalLeads
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [NotMapped]
        [Required]
        //[Range(typeof(DateTime), "1/1/1966", "1/1/2020")]
        [Display(Name ="Date Start Leads")]
        public DateTime Date1 { get; set; }

        [NotMapped]
        [Required]
        //[Range(typeof(DateTime), "1/1/1966", "1/1/2020")]
        [Display(Name = "Date End Leads")]
        public DateTime Date2 { get; set; }

    }
}
