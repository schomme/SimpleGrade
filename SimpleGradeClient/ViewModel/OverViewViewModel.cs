using SimpleGradeClient.Base;
using System.Collections.ObjectModel;

namespace SimpleGradeClient.ViewModel
{
    public class OverViewViewModel : ViewModelBase
    {
        private GroupBase _group;

        public OverViewViewModel(GroupBase group)
        {
            _group = group;
        }

        public GroupBase Group { get => _group; set => SetField(ref _group, value); }

        public ObservableCollection<GroupBase> FlattenList => Group.FlatChildrensList;

    }
}
