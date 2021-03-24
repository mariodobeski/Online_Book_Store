using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Areas.Identity
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public int Name { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@")]
    }
}
