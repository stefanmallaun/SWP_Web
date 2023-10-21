using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Grundlagen.Models {
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        [NotMapped]
        public string PwdRetype { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }


        
    }
}
