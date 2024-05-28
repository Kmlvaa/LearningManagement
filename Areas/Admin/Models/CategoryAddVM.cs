using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LearningManagement.Areas.Admin.Models
{
    public class CategoryAddVM
    {
        public int Id { get; set; }
        public string Category { get; set; }
        [ValidateNever]
        public string ?ErrorMessage { get; set; }
    }
}
