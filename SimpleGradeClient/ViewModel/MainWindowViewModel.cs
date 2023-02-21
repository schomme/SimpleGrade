using Newtonsoft.Json;
using SimpleGradeClient.Base;
using SimpleGradeClient.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace SimpleGradeClient.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private GroupViewModel _Group = new GroupViewModel(null, RootGroup.Get());
        private ViewModelBase? _SubViewModel;

        public MainWindowViewModel()
        {
            LoadCommand = new RelayCommand(ExecuteLoad);
            SaveCommand = new RelayCommand(ExecuteSave);
            AddGroupCommand = new RelayCommand(ExecuteAddGroup);

            SubViewModel = new AddGroupViewModel(Groups);
        }

        #region Properties

        public GroupViewModel Groups { get => _Group; set { SetField(ref _Group, value); } }
        public ViewModelBase SubViewModel { get => _SubViewModel; set => SetField(ref _SubViewModel, value); }

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

        private void ExecuteAddGroup(object? o)
        {
            this.SubViewModel = new AddGroupViewModel(_Group);
        }
        #endregion
    }

}
