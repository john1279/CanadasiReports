using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Models
{
    [Table("accounts")]
    public class ImmigrationAccount
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("date_entered")]
        public DateTime DateEntered { get; set; }

        [Column("date_modified")]
        public DateTime DateModified { get; set; }

        [Column("modified_user_id")]
        public string ModifiedUserId { get; set; } 

        [Column("created_by")]
        public string CreatedBy { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; }

        [Column("assigned_user_id")]
        public string AssignedUserId { get; set; }

        [Column("account_type")]
        public string AccountType { get; set; }

        [Column("industry")]
        public string Industry { get; set; }

        [Column("annual_revenue")]
        public string AnnualRevenue { get; set; }

        [Column("phone_fax")]
        public string PhoneFax { get; set; }

        [Column("billing_address_street")]
        public string BillingAddressStreet { get; set; }

    }
}
