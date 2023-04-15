namespace SimpleGradeClient.ViewModel
{
    class ViewManagerViewModel : ViewModelBase
    {
        private MainWindowViewModel _mainWindowViewModel;

        public ViewManagerViewModel(MainWindowViewModel vm)
        {
            _mainWindowViewModel = vm;
        }

        public void SetSubViewOverView(GroupViewModel group, GroupViewModel selected = null)
        {
            var parent = group ?? _mainWindowViewModel.Groups;
            _mainWindowViewModel.SubViewModel = new OverViewViewModel(parent);
            var s = group ?? _mainWindowViewModel.Groups;
            _mainWindowViewModel.DeselectAll();
            s.IsSelected = true;
        }
        public void SetSubViewAddGroup(GroupViewModel group)
        {
            _mainWindowViewModel.SubViewModel = new AddGroupViewModel(this, group);
        }
    }
}
