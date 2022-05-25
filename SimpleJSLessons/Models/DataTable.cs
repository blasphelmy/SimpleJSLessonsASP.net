using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleJSLessons.Models
{
    public partial class DataTable
    {
        public DataTable()
        {
            Authors = new HashSet<Authors>();
            DataDataTable = new HashSet<DataDataTable>();
            UserSavedDemos = new HashSet<UserSavedDemos>();
            UserSavedLessons = new HashSet<UserSavedLessons>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column("dataHash")]
        [StringLength(24)]
        public string DataHash { get; set; }
        [Required]
        [Column("data")]
        public string Data { get; set; }
        [Column("title")]
        [StringLength(128)]
        public string Title { get; set; }
        [Column("dateCreated", TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Authors> Authors { get; set; }
        public virtual ICollection<DataDataTable> DataDataTable { get; set; }
        public virtual ICollection<UserSavedDemos> UserSavedDemos { get; set; }
        public virtual ICollection<UserSavedLessons> UserSavedLessons { get; set; }
    }
}
