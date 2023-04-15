namespace SimpleGradeClient.ViewModel
{
    public class OverViewViewModel : ViewModelBase
    {
        private GroupViewModel _groupViewModel;
        public OverViewViewModel(GroupViewModel group)
        {
            _groupViewModel = group;
        }

        public GroupViewModel Group => _groupViewModel;
    }
}
