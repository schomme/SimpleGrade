using SimpleGrade.Base.Enums;
using SimpleGrade.Base.Interfaces;

namespace SimpleGrade.Base.Model.Person
{
    public class Person : IPerson
    {
        public List<Connection.Connection>? Outgoing { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Street { get; set; }
        public int Zip { get; set; }
        public string City { get; set; }
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public int ChangedBy { get; set; }
        public DateTime DeletedOn { get; set; }
        public int DeletedBy { get; set; }
        ObjectType IBaseObject.ObjectType => ObjectType.Person;
    }
}
