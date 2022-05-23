using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleJSLessons.Models
{
    [Table("apiUserInformation")]
    public partial class ApiUserInformation
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("accountHash")]
        [StringLength(64)]
        public string AccountHash { get; set; }
        [Required]
        [Column("firstName")]
        [StringLength(24)]
        public string FirstName { get; set; }
        [Required]
        [Column("lastName")]
        [StringLength(24)]
        public string LastName { get; set; }

        public virtual ApiUser AccountHashNavigation { get; set; }
    }
}
