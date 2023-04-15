using SimpleGrade.Base.Enums;

namespace SimpleGrade.Base.Model
{
    public class ClassGroup : GroupBase
    {
        public new ObjectType ObjectType => ObjectType.Class;

        public int Number { get; set; }
        public string Suffix { get; set; } = string.Empty;
    }

}
