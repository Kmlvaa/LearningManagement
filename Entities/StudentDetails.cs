namespace LearningManagement.Entities
{
    public class StudentDetails
    {
        public int Id { get; set; }
        public string Profession { get; set; }
        public string ImageUrl { get; set; }
        public Comment Comment { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
