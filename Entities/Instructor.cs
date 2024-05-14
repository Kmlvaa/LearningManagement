namespace LearningManagement.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Profession { get; set; }
        public string ImageUrl { get; set; }
        public List<Course> Courses { get; set; }
    }
}
