using SimpleGrade.Models.Interface;

namespace SimpleGrade.Models
{
    public class Student : IModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public string Street { get; set; }
        public int Zip { get; set; }
        public string City { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }

        public bool IsEqual(object other)
        {
            var otherObject = other as Student;

            return string.Equals(this.Firstname, otherObject.Firstname, StringComparison.CurrentCultureIgnoreCase)
                && string.Equals(this.Lastname, otherObject.Lastname, StringComparison.CurrentCultureIgnoreCase)
                && this.Birthday == otherObject.Birthday;
        }
    }
}
