using Newtonsoft.Json;
using SimpleGradeClient.Base;
using System.IO;
using System.Windows;

namespace SimpleGradeClient.Commands
{
    public class SaveCommand : CommandBase
    {
        public override void Execute(object? parameter)
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
                var json = JsonConvert.SerializeObject(parameter, settings);
                file.Write(json);
            }
        }
    }
}
