using Newtonsoft.Json;
using SimpleGradeClient.Base;
using SimpleGradeClient.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;

namespace SimpleGradeClient.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private GroupViewModel _Group = new GroupViewModel(null, RootGroup.Get());
        private ViewModelBase? _SubViewModel;
        private ViewManagerViewModel _viewManagerViewModel;

        public MainWindowViewModel()
        {
            LoadCommand = new RelayCommand(ExecuteLoad);
            SaveCommand = new RelayCommand(ExecuteSave);
            AddGroupCommand = new RelayCommand(ExecuteAddGroupView);
            RemoveGroupCommand = new RelayCommand(ExecuteRemoveGroup);
            //SubViewModel = new AddGroupViewModel(Groups);
            SubViewModel = new OverViewViewModel(_Group);
            _viewManagerViewModel = new ViewManagerViewModel(this);
            _Group.IsSelected = true;
        }


        #region Properties

        public GroupViewModel Groups { get => _Group; set { SetField(ref _Group, value); } }
        public ViewModelBase SubViewModel { get => _SubViewModel; set => SetField(ref _SubViewModel, value); }
        public GroupViewModel SelectedGroup => Groups.AllChildren.FirstOrDefault(i => i.IsSelected) ?? Groups;

        #endregion

        #region Commands

        public RelayCommand AddGroupCommand { get; }
        public RelayCommand RemoveGroupCommand { get; }
        public RelayCommand LoadCommand { get; }
        public RelayCommand SaveCommand { get; }


        #endregion

        #region Command Methods

        private void ExecuteLoad(object? _)
        {
            try
            {
                if (!File.Exists(Constants.FilePath)) throw new FileNotFoundException(Constants.FilePath);
                var json = File.ReadAllText(Constants.FilePath) ?? string.Empty;
                if (string.IsNullOrWhiteSpace(json)) throw new NullReferenceException(Constants.FilePath);

                //this.Groups = RootGroup.FromJson(json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex}");
            }
        }

        private void ExecuteSave(object? _)
        {
            if (File.Exists(Constants.FilePath))
            {
                var result = MessageBox.Show("The file already exitsts. Overwrite?", "Save", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (result != MessageBoxResult.Yes) return;
            }

            File.Delete(Constants.FilePath);

            using (StreamWriter file = File.CreateText(Constants.FilePath))
            {
                var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented, PreserveReferencesHandling = PreserveReferencesHandling.All };
                var json = JsonConvert.SerializeObject(this.Groups, settings);
                file.Write(json);
            }
        }

        private void ExecuteAddGroupView(object? _)
        {
            _viewManagerViewModel.SetSubViewAddGroup(SelectedGroup);
        }
        private void ExecuteRemoveGroup(object? obj)
        {
            var group = SelectedGroup;
            if (group is null) throw new NullReferenceException("No Group is selected");

            if (group.Children.Any())
            {
                var result = MessageBox.Show($"The Group and {group.Children.Count} children will be deleted.", "Delete Group", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
                if (result != MessageBoxResult.OK) return;
            }
            group.Parent?.Children.Remove(group);
        }

        public void DeselectAll()
        {
            Groups.IsSelected = false;
            Groups.AllChildren.Where(i => i.IsSelected).Select(i => { i.IsSelected = false; return i; });
        }
        #endregion
    }

}
