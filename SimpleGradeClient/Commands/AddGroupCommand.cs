using SimpleGradeClient.Base;
using SimpleGradeClient.Model;

namespace SimpleGradeClient.Commands
{
    public class AddGroupCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (parameter is GroupBase group)
            {
                group.AddChild(new Subject() { Name = "Hello World" });
            }
        }
    }
}
