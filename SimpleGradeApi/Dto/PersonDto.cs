using SimpleGrade.Base.Enums;
using SimpleGrade.Base.Interfaces;
using SimpleGrade.Base.Model.Connection;
using System.Text.Json.Serialization;

namespace SimpleGradeApi.Dto
{
    public class PersonDto : IPerson
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthday { get; set; } = DateTime.MinValue;
        public string Street { get; set; } = string.Empty;
        public int Zip { get; set; } = 0;
        public string City { get; set; } = string.Empty;
        public int Id { get; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;
        public int CreatedBy { get; private set; } = 0;
        public DateTime ChangedOn { get; private set; } = DateTime.MinValue;
        public int ChangedBy { get; private set; } = 0;
        public DateTime DeletedOn { get; private set; } = DateTime.MinValue;
        public int DeletedBy { get; private set; } = 0;
        [JsonIgnore]
        public ObjectType ObjectType { get; private set; } = ObjectType.Person;
        public List<Connection> Outgoing { get; } = new List<Connection>();

    }
}
