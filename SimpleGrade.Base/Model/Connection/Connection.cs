using SimpleGrade.Base.Enums;
using SimpleGrade.Base.Interfaces;
using SimpleGrade.Base.Model.Base;

namespace SimpleGrade.Base.Model.Connection
{
    //Do Not inherite from BaseObject directly
    //The ef will be unable to run the migration script
    public class Connection : IBaseObject
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public int ChangedBy { get; set; }
        public DateTime DeletedOn { get; set; }
        public int DeletedBy { get; set; }
        public ObjectType ObjectType => ObjectType.Connection;

        public int TargetId { get; set; }
        public BaseObject Target { get; set; }
    }
}
