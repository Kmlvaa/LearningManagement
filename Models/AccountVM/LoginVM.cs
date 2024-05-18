using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LearningManagement.Models.AccountVM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [MinLength(4, ErrorMessage = "Password should be at least 4 chars longs!")]
        [MaxLength(255, ErrorMessage = "Password should be at most 255 chars longs!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [ValidateNever]
        public string ErrorMessage { get; set; }
    }
}