using SimpleGrade.Base.Enums;

namespace SimpleGrade.Base.Interfaces
{
    public interface IBaseObject
    {
        public int Id { get; }
        public DateTime CreatedOn { get; }
        public int CreatedBy { get; }
        public DateTime ChangedOn { get; }
        public int ChangedBy { get; }
        public DateTime DeletedOn { get; }
        public int DeletedBy { get; }
        public ObjectType ObjectType { get; }

    }
}
