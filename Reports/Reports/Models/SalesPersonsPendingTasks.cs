using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Models
{
    [Table("SalesPersonsPendingTasks")]
    public class SalesPersonsPendingTasks
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [NotMapped]
        [Display(Name = "Date Start")]
        public DateTime Date1 { get; set; }

        [NotMapped]
        [Display(Name = "Date End")]
        public DateTime Date2 { get; set; }

        [NotMapped]
        [Display(Name = "Status Lead")]
        public string StatusLead { get; set; }

        [NotMapped]
        [Display(Name = "Sales Person")]
        public string SalesPerson { get; set; }
    }
}
