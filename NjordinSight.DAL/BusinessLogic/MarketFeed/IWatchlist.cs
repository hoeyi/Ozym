using System.Collections.Generic;

namespace NjordinSight.BusinessLogic.MarketFeed
{
    /// <summary>
    /// Represents a service that generates data randomly to represent the behavior of a stock 
    /// market watchlist.
    /// </summary>
    public interface IWatchlist
    {
        /// <summary>
        /// Gets a collection of pre-defined market quotes.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Quote"/>.</returns>
        IEnumerable<Quote> GetQuotes();
        
        /// <summary>
        /// Updates the given collection of <see cref="Quote" /> records.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Quote"/>.</returns>
        IEnumerable<Quote> UpdateQuotes(IList<Quote> quotes);
    }
}