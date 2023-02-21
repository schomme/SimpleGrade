using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace SimpleGradeClient.Base
{
    public class Person : NotifyPropertyChangedBase
    {
        private string _firstname = string.Empty;
        private string _lastname = string.Empty;
        private ObservableCollection<GroupBase> _membership = new ObservableCollection<GroupBase>();

        public string Firstname
        {
            get => _firstname;
            set
            {
                SetField(ref _firstname, value);
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string Lastname
        {
            get => _lastname;
            set
            {
                SetField(ref _lastname, value);
                OnPropertyChanged(nameof(FullName));
            }
        }
        [JsonIgnore]
        public string FullName { get => $"{Firstname} {Lastname}"; }
        [JsonProperty(IsReference = true)]
        public ObservableCollection<GroupBase> Membership { get => _membership; }


    }
}
