using Ozym.ChangeTracking;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ozym.Test.ChangeTracking
{
    /// <summary>
    /// Simple implementation satisfying type contraint for <see cref="TrackingEnumerable{T}"/>.
    /// </summary>
    public class SampleObject : INotifyPropertyChanged
    {
        private string _sampleProperty;

        /// <summary>
        /// Gets or sets the property value, invoking <see cref="PropertyChanged"/> if the value is 
        /// changed.
        /// </summary>
        public string SampleProperty
        {
            get => _sampleProperty;
            set
            {
                if(_sampleProperty != value)
                {
                    _sampleProperty = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
