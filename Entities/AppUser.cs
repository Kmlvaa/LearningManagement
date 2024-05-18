using Microsoft.AspNetCore.Identity;

namespace LearningManagement.Entities
{
    public class AppUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public StudentDetails StudentDetails { get; set; }
    }
}
