using JsonSubTypes;
using Newtonsoft.Json;
using SimpleGradeClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SimpleGradeClient.Base
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(GroupBase), nameof(RootGroup))]
    [JsonSubtypes.KnownSubType(typeof(GroupBase), nameof(SchoolClass))]
    [JsonSubtypes.KnownSubType(typeof(GroupBase), nameof(Subject))]
    public abstract class GroupBase : NotifyPropertyChangedBase
    {
        public static HashSet<GroupBase> All = new HashSet<GroupBase>();

        private Guid _id;
        private string _name = string.Empty;
        private string _description = string.Empty;
        private bool _isSelected = false;
        private GroupBase? _ParentGroup = null;

        public GroupBase()
        {
            _id = Guid.NewGuid();
            GroupBase.All.Add(this);
        }
        [JsonConstructor]
        public GroupBase(Guid Id)
        {
            _id = Id;
        }
        ~GroupBase()
        {
            GroupBase.All.Remove(this);
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
        public GroupBase ParentGroup { get => _ParentGroup; set => SetField(ref _ParentGroup, value); }
        public ObservableCollection<GroupBase> Children { get; } = new ObservableCollection<GroupBase>();

        public void AddChild(GroupBase child)
        {
            child.ParentGroup = this;
            Children.Add(child);
            OnPropertyChanged(nameof(Children));
        }

        public void AddChildRange(IEnumerable<GroupBase> children)
        {
            foreach (var child in children)
            {
                AddChild(child.ParentGroup);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}", Id, Name, Description, IsSelected);
        }
    }
}
