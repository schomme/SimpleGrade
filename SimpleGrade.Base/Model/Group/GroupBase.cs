using SimpleGrade.Base.Enums;
using SimpleGrade.Base.Interfaces;
using SimpleGrade.Base.Model.Base;

namespace SimpleGrade.Base.Model
{
    public abstract class GroupBase : BaseObject, IConnectable
    {
        public new ObjectType ObjectType => ObjectType.Group;

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Connection.Connection>? Outgoing { get; set; }

    }
}
