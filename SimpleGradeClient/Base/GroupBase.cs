using JsonSubTypes;
using Newtonsoft.Json;
using SimpleGradeClient.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SimpleGradeClient.Base
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(GroupBase), nameof(RootGroup))]
    [JsonSubtypes.KnownSubType(typeof(GroupBase), nameof(SchoolClass))]
    [JsonSubtypes.KnownSubType(typeof(GroupBase), nameof(Subject))]
    public abstract class GroupBase : NotifyPropertyChangedBase
    {
        private Guid _id;
        private string _name = string.Empty;
        private string _description = string.Empty;
        private bool _isSelected = false;
        private GroupBase? _parentGroup = null;
        private string _iconPath = Icons.Path.Default;
        private ObservableCollection<GroupBase> _children = new ObservableCollection<GroupBase>();
        private ObservableCollection<Person> _member = new ObservableCollection<Person>();

        public GroupBase()
        {
            _id = Guid.NewGuid();
            AddGroupCommand = new RelayCommand(ExecuteAddGroup);
            RemoveGroupCommand = new RelayCommand(ExecuteRemoveGroup);
        }

        [JsonConstructor]
        public GroupBase(Guid Id)
        {
            this.Id = Id;
        }

        public Guid Id
        {
            get => _id;
            set { SetField(ref _id, value); }
        }
        public string Name { get => _name; set => SetField(ref _name, value); }
        public string Description { get => _description; set => SetField(ref _description, value); }
        [JsonIgnore]
        public bool IsSelected { get => _isSelected; set => SetField(ref _isSelected, value); }
        [JsonProperty(IsReference = true)]
        public GroupBase ParentGroup { get => _parentGroup; set => SetField(ref _parentGroup, value); }
        public ObservableCollection<GroupBase> Children { get => _children; }
        public ObservableCollection<Person> Member { get => _member; }
        public ObservableCollection<GroupBase> FlatChildrensList => AllChildren();
        public string IconPath { get => _iconPath; set => SetField(ref _iconPath, value); }
        public RelayCommand AddGroupCommand { get; }
        public RelayCommand RemoveGroupCommand { get; }

        public void AddChild(GroupBase child)
        {
            child.ParentGroup = this;
            Children.Add(child);
            OnPropertyChanged(nameof(Children));
            OnPropertyChanged(nameof(FlatChildrensList));

        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}", Id, Name, Description, IsSelected);
        }

        private ObservableCollection<GroupBase> AllChildren()
        {
            var list = new ObservableCollection<GroupBase>(Children);
            foreach (var item in Children.ToList())
            {
                var sublist = item.AllChildren();
                foreach (var subitem in sublist)
                {
                    if (!list.Contains(subitem)) list.Add(subitem);
                }
            }
            return list;
        }

        private void ExecuteAddGroup(object? o)
        {
            if (o == null) return;
            if (o is GroupBase group) this.AddChild(group);
        }

        private void ExecuteRemoveGroup(object? _)
        {
            var result = MessageBox.Show("Are you sure that you want to the group and all of it's children?", "Remove", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

            if (result != MessageBoxResult.Yes) return;
            this.ParentGroup?.Children.Remove(this);
        }

    }
}
