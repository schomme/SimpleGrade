namespace SimpleGrade.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}
