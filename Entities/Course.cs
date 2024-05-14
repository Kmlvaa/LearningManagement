namespace LearningManagement.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Hours { get; set;}
        public string BackgroundImageUrl { get; set; }
        public string InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
