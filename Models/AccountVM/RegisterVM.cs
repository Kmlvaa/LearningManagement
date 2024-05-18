using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LearningManagement.Models.AccountVM
{
    public class RegisterVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [MinLength(4, ErrorMessage = "Password should be at least 4 chars longs!")]
        [MaxLength(255, ErrorMessage = "Password should be at most 255 chars longs!")]
        public string Password { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Password should be at least 4 chars longs!")]
        [MaxLength(255, ErrorMessage = "Password should be at most 255 chars longs!")]
        public string PasswordConfirmed { get; set; }
        [ValidateNever]
        public string ErrorMessage { get; set; }
    }
}
