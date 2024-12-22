using System.ComponentModel.DataAnnotations;

namespace Test.Models.ModelView
{
    public class UserDoc
    {
        [Required,MaxLength(100)]
        public string FName { get; set; }
        [Required, MaxLength(100)]
        public string LName { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        [Required, MaxLength(100)]
        public string Password { get; set; }
    }
}
