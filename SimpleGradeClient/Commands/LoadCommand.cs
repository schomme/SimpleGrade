using SimpleGradeClient.Base;
using SimpleGradeClient.Model;
using SimpleGradeClient.ViewModel;
using System;
using System.Diagnostics;
using System.IO;
namespace SimpleGradeClient.Commands
{
    public class LoadCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {

            try
            {

                if (parameter == null) throw new ArgumentNullException(nameof(parameter));

                if (parameter is MainWindowViewModel viewModel)
                {
                    if (!File.Exists(Constants.FilePath)) throw new FileNotFoundException(Constants.FilePath);
                    var json = File.ReadAllText(Constants.FilePath) ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(json)) throw new NullReferenceException(Constants.FilePath);

                    viewModel.Groups = RootGroup.FromJson(json);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex}");
            }

        }
    }
}
