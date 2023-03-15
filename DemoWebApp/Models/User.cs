using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebApp.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        /*
            A valid username should start with an alphabet so, [A-Za-z].
            All other characters can be alphabets, numbers or an underscore so, [A-Za-z0-9_].
            Since length constraint was given as 8-30 and we had already fixed the first character, so we give {7,29}.
            We use ^ and $ to specify the beginning and end of matching.
        */
        [RegularExpression("^[A-Za-z][A-Za-z0-9_]{7,29}$", ErrorMessage = "User name should start with an alphabet. All other characters can be alphabets, numbers or an underscore. Length constraint should be as 8-30.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email { get; set; }

        public string DisplayName { get; set; }

        [Range(18, 100)]
        public int? Age { get; set; }
    }
}
