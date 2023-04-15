using SimpleGradeClient.Base;
using SimpleGradeClient.Model;

namespace SimpleGradeClient.ViewModel
{
    class AddGroupViewModel : ViewModelBase
    {
        private ViewManagerViewModel _viewManagerViewModel;
        private GroupViewModel _parent;
        private GroupViewModel _group;


        public AddGroupViewModel(ViewManagerViewModel viewmanager, GroupViewModel parent)
        {
            _viewManagerViewModel = viewmanager;
            _parent = parent;
            _group = new GroupViewModel(_parent, new DefaultGroup());
            SaveCommand = new RelayCommand(SaveExecute);
            SaveAndExitCommand = new RelayCommand(SaveAndExitExecute);
        }

        public GroupViewModel Group => _group;
        public GroupViewModel Parent => _parent;

        public RelayCommand SaveCommand { get; }
        public RelayCommand SaveAndExitCommand { get; }

        private void SaveExecute(object? o)
        {
            AddGroup();
        }

        private void SaveAndExitExecute(object? o)
        {
            AddGroup(true);
        }
        private void AddGroup(bool exit = false)
        {
            _parent.AddChildGroupCommand.Execute(_group);
            if (exit)
            {
                _viewManagerViewModel.SetSubViewOverView(null, _group);
                return;
            }
            _viewManagerViewModel.SetSubViewAddGroup(_parent);
        }
    }
}
