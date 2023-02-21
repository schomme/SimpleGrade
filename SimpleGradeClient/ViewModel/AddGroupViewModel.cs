using SimpleGradeClient.Base;
using SimpleGradeClient.Model;

namespace SimpleGradeClient.ViewModel
{
    class AddGroupViewModel : ViewModelBase
    {
        private GroupBase _parent;
        private GroupBase _group;

        public AddGroupViewModel(GroupBase parent)
        {
            _parent = parent;
            _group = new DefaultGroup();
            SaveCommand = new RelayCommand(ExecuteSaveCommand);
        }

        public GroupBase Group => _group;
        public GroupBase Parent => _parent;

        public RelayCommand SaveCommand { get; }

        private void ExecuteSaveCommand(object? o)
        {
            Parent.AddGroupCommand.ExecuteCommand.Invoke(Group);
        }
    }
}
