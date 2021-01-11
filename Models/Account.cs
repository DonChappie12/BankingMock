using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace banking.Models
{
    public class Account
    {
        public Guid Id { get; set;}

        [Required]
        public string TypeOfAccount { get; set; }

        [Required]
        public double Amount { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created_At { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Updated_At { get; set; }
        public virtual User user { get; set; }

        public enum AccountType
        {
            Checkings,
            Savings
        }
    }
}