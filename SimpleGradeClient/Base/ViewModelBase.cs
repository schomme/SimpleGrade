using SimpleGradeClient.Base;
using System.Collections.Specialized;

namespace SimpleGradeClient.ViewModel
{
    public abstract class ViewModelBase : NotifyPropertyChangedBase
    {
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        protected void OnCollectionAdd(string propertyName) => CollectionChanged?.Invoke(this, new(NotifyCollectionChangedAction.Add, propertyName));
        protected void OnCollectionRemoved(string propertyName) => CollectionChanged?.Invoke(this, new(NotifyCollectionChangedAction.Remove, propertyName));
    }
}
