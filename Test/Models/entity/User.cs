using System.ComponentModel.DataAnnotations;

namespace Test.Models.entity
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string FName { get; set; }
        [MaxLength(100)]
        public string LName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }


    }
}
