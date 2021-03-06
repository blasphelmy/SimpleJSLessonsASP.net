using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleJSLessons.Models
{
    [Table("apiUser")]
    public partial class ApiUser
    {
        public ApiUser()
        {
            LikesTable = new HashSet<LikesTable>();
            SessionModel = new HashSet<SessionModel>();
            UserSavedDemos = new HashSet<UserSavedDemos>();
            UserSavedLessons = new HashSet<UserSavedLessons>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("accountHash")]
        [StringLength(64)]
        public string AccountHash { get; set; }
        [Required]
        [Column("username")]
        [StringLength(30)]
        public string Username { get; set; }
        [Column("dateCreated", TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
        [Column("profileData")]
        public string ProfileData { get; set; }

        public virtual ApiUserInformation ApiUserInformation { get; set; }
        public virtual ICollection<LikesTable> LikesTable { get; set; }
        public virtual ICollection<SessionModel> SessionModel { get; set; }
        public virtual ICollection<UserSavedDemos> UserSavedDemos { get; set; }
        public virtual ICollection<UserSavedLessons> UserSavedLessons { get; set; }
    }
}
