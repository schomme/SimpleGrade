using SimpleGradeClient.Base;
using SimpleGradeClient.Model;

namespace SimpleGradeClient.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private GroupBase _Group = RootGroup.Get();

        public object selectedItem { get; set; }

        public MainWindowViewModel()
        {
            for (int i = 0; i < 1; i++)
            {
                var g1 = new SchoolClass() { Name = $"Class {i}" };

                for (int j = 0; j < 5; j++)
                {
                    var g2 = new Subject() { Name = $"Group {i}.{j}" };

                    for (int k = 0; k < 5; k++)
                    {
                        g2.AddChild(new Subject() { Name = $"Group {i}.{j}.{k}" });
                    }

                    g1.AddChild(g2);
                }
                Groups.AddChild(g1);
            }

        }

        public GroupBase Groups { get => _Group; set { SetField(ref _Group, value); } }
    }

}
