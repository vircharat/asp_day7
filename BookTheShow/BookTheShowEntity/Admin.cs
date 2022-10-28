using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookTheShowEntity
{
    public class Admin
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }
        public string AdminName { get; set; }

        public string AdminEmail { get; set; }

        public string AdminPassword { get; set; }
    }
}
