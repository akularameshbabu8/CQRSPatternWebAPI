namespace Domain.Models
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Base entity class contains common data.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the URL from where was downloaded the entity.
        /// </summary>
        [JsonProperty]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the date of creation of the entity.
        /// </summary>
        [JsonProperty]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the date of last modification.
        /// </summary>
        [JsonProperty]
        public DateTime Edited { get; set; }

        /// <summary>
        /// Gets the path.
        /// </summary>
        protected abstract string EntryPath { get; }

        /// <summary>
        /// Gets the path for extending base URL API.
        /// </summary>
        /// <returns>System.String the path.</returns>
        public string GetPath()
        {
            return EntryPath;
        }
    }
}
