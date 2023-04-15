using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SimpleGradeClient.Base
{
    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new(propertyName));
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "", params string[] alsoNotify)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            Debug.WriteLine($"{propertyName}: {field} => {value}");
            field = value;
            OnPropertyChanged(propertyName);
            foreach (var notify in alsoNotify)
            {
                OnPropertyChanged(notify);
            }
            return true;
        }
    }
}
