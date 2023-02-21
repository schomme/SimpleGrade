using SimpleGradeClient.Base;
using SimpleGradeClient.Model;

namespace SimpleGradeClient.ViewModel
{
    class AddGroupViewModel : ViewModelBase
    {
        private GroupViewModel _parent;
        private GroupViewModel _group;

        public AddGroupViewModel(GroupViewModel parent)
        {
            _parent = parent;
            _group = new GroupViewModel(_parent, new DefaultGroup());
            SaveCommand = new RelayCommand(SaveExecute);
        }

        public GroupViewModel Group => _group;
        public GroupViewModel Parent => _parent;

        public RelayCommand SaveCommand { get; }

        private void SaveExecute(object? o)
        {
            _parent.AddChildGroupCommand.Execute(_group);
        }
    }
}
