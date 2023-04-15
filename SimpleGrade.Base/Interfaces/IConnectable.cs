using SimpleGrade.Base.Model.Connection;

namespace SimpleGrade.Base.Interfaces
{
    public interface IConnectable
    {
        public List<Connection>? Outgoing { get; }
    }
}
