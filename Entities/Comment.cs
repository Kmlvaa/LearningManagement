namespace LearningManagement.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int StudentId { get; set; }
        public StudentDetails Student { get; set; }
    }
}
   