using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Grundlagen.Models {
    public class User {
        [Key]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        [NotMapped]
        public string PwdRetype { get; set; }
        
        public DateTime Birthdate { get; set; }


        
    }
}
