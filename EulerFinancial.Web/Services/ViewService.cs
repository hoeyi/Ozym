using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EulerFinancial.Web.Services
{
    public class ViewDataService : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string? _header;

        /// <summary>
        /// Gets or sets the header element for the current page.
        /// </summary>
        public string? Header
        {
            get => _header;
            set
            {
                if(_header != value)
                {
                    _header = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
