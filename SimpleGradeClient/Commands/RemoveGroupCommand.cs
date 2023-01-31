using SimpleGradeClient.Base;
using System.Windows;

namespace SimpleGradeClient.Commands
{
    public class RemoveGroupCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (parameter == null) { return; }

            if (parameter is GroupBase group)
            {
                var result = MessageBox.Show("Are you sure that you want to the group and all of it's children?", "Remove", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

                if (result != MessageBoxResult.Yes) return;

                group.ParentGroup?.Children.Remove(group);
                GroupBase.All.Remove(group);
            }
        }
    }
}
