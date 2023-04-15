using SimpleGrade.Base.Enums;
using SimpleGrade.Base.Interfaces;
using SimpleGrade.Base.Model.Base;

namespace SimpleGrade.Base.Model
{
    public class Grade : BaseObject, IConnectable
    {
        public new ObjectType ObjectType => ObjectType.Group;

        public GradeType GradeType { get; set; } = GradeType.Standard;
        public decimal RawValue { get; set; }
        public List<Connection.Connection>? Outgoing { get; set; }
    }
}
