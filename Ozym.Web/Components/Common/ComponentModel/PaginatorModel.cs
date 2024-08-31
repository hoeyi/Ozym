using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ozym.Web.Components.Common
{
    /// <summary>
    /// Provides properties for presenting and modifying paging parameters.
    /// </summary>
    public class PagerModel : INotifyPropertyChanged
    {
        private int _pageIndex;
        private int _itemCount;
        private int _totalItemCount;
        private int _pageSize;

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets the index of the page returned.
        /// </summary>
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                if (_pageIndex != value && value > 0)
                {
                    _pageIndex = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets the count of records for the page matching <see cref="PageIndex" />.
        /// </summary>
        public int ItemCount
        {
            get { return _itemCount; }
            set
            {
                if (_itemCount != value)
                    _itemCount = value;
            }
        }

        /// <summary>
        /// Gets the total count of records matching the query predicate.
        /// </summary>
        public int TotalItemCount
        {
            get { return _totalItemCount; }
            set
            {
                if (_totalItemCount != value)
                    _totalItemCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the desired record count per page.
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (_pageSize != value)
                {
                    _pageSize = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets the total estimated pages for all records matching the query predicate.
        /// </summary>
        public int PageCount => (int)Math.Ceiling(TotalItemCount / (double)PageSize);

        /// <summary>
        /// Gets the string message describing the record result set.
        /// </summary>
        public string RecordReport => string.Format(
            Strings.Paginator_Caption_RecordCount, arg0: ItemCount, arg1: TotalItemCount);

        /// <summary>
        /// Increments the index to the next value unless the last value has been reached.
        /// </summary>
        public void MoveNext()
        {
            if (PageIndex < PageCount)
                PageIndex++;
        }

        /// <summary>
        /// Increments the index to the next value unless the first value has been reached.
        /// </summary>
        public void MovePrevious()
        {
            if (PageIndex > 1)
                PageIndex--;
        }

        /// <summary>
        /// Moves the index to the last value.
        /// </summary>
        public void MoveEnd()
        {
            PageIndex = PageCount;
        }

        /// <summary>
        /// Moves the index to the base value 1.
        /// </summary>
        public void MoveStart()
        {
            PageIndex = 1;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EventCallback<int> IndexChanged { get; init; }

        public EventCallback<int> PageSizeChanged { get; init; }
    }
}
