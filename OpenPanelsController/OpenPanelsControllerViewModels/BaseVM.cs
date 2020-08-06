using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OpenPanelsControllerViewModels
{
    public class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropetyChanged([CallerMemberName] string propertyName = "")
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}