using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LearningManagement.Areas.Admin.Models
{
    public class CategoryEditVM
    {
        public string Category { get; set; }
        [ValidateNever]
        public string ErrorMessage { get; set; }
    }
}
