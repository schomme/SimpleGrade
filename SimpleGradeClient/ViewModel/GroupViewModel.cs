using SimpleGradeClient.Base;
using SimpleGradeClient.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SimpleGradeClient.ViewModel
{
    class GroupViewModel : NotifyPropertyChangedBase
    {
        private GroupViewModel? _parent;
        private GroupBase _group;
        private Lazy<ObservableCollection<GroupViewModel>> _children;
        private bool _isSelected;

        public string Name
        {
            get => _group.Name;
            set
            {
                if (string.Equals(_group.Name, value)) return;
                _group.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Description
        {
            get => _group.Description;
            set
            {
                if (string.Equals(_group.Description, value)) return;
                _group.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public string IconPath
        {
            get => _group.IconPath;
            set
            {
                if (string.Equals(_group.IconPath, value)) return;
                _group.IconPath = value;
                OnPropertyChanged(nameof(IconPath));
            }
        }
        public GroupViewModel? Parent { get => _parent; private set => SetField(ref _parent, value); }
        public ObservableCollection<GroupViewModel> Children => _children.Value;
        public bool IsSelected { get => _isSelected; set => SetField(ref _isSelected, value); }
        public RelayCommand AddChildGroupCommand { get; }
        public GroupViewModel(GroupViewModel? parent, GroupBase group)
        {
            Parent = parent;
            _group = group;
            _children = new Lazy<ObservableCollection<GroupViewModel>>(() => LoadChildren());
            AddChildGroupCommand = new RelayCommand(AddChildGroupExecute);
        }

        private ObservableCollection<GroupViewModel> LoadChildren()
        {
            var collection = new ObservableCollection<GroupViewModel>(_group.Children.Select(i => new GroupViewModel(this, i)).ToList());
            return collection;
        }

        private void AddChildGroupExecute(object? o)
        {
            if (o is GroupViewModel group)
            {
                this.Children.Add(new GroupViewModel(this, group._group));
            }
            else if (o is GroupBase groupbase)
            {
                this.Children.Add(new GroupViewModel(this, groupbase));
            }
            else
            {
                this.Children.Add(new GroupViewModel(this, new DefaultGroup()));
            }

        }
    }
}
