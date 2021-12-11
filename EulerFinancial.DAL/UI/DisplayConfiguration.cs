using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EulerFinancial.UI
{
    /// <summary>
    /// Represents a collection of column settings applicable to a viewable list
    /// </summary>
    public class DisplayConfiguration
    {
        /// <summary>
        /// Con
        /// </summary>
        /// <param name="objectGuid"></param>
        [JsonConstructor]
        public DisplayConfiguration(
            int id,
            Guid objectGuid,
            string name,
            Type applicableTo,
            Dictionary<string, int> displayFields
            )
        {
            Id = id;
            ObjectGuid = objectGuid;
            Name = name;
            ApplicableTo = applicableTo;
            DisplayOrder = displayFields;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="DisplayConfiguration"/> with 
        /// a newly-assigned Guid.
        /// </summary>
        public DisplayConfiguration()
        {
            ObjectGuid = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the id of this configuration.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets the GUID for this configuration.
        /// </summary>
        public Guid ObjectGuid { get; }
        
        /// <summary>
        /// Gets or sets the name of this coniguration.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the type of model to which this configuration applies.
        /// </summary>
        public Type ApplicableTo { get; set; }

        /// <summary>
        /// Gets or sets the column settings for this configuration.
        /// </summary>
        public Dictionary<string, int> DisplayOrder { get; set; }
    }
}
