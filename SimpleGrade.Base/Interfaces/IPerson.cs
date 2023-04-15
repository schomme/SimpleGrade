namespace SimpleGrade.Base.Interfaces
{
    public interface IPerson : IBaseObject, IConnectable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Street { get; set; }
        public int Zip { get; set; }
        public string City { get; set; }
    }
}
