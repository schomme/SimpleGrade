using SimpleGrade.Base.Enums;
using SimpleGrade.Base.Interfaces;

namespace SimpleGrade.Base.Model.Base
{
    public abstract class BaseObject : IBaseObject
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public int ChangedBy { get; set; }
        public DateTime DeletedOn { get; set; }
        public int DeletedBy { get; set; }
        public ObjectType ObjectType => ObjectType.None;
    }
}
