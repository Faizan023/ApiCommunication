using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace loginmodel
{
    [Table("login")]
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? gender { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
    }
}
