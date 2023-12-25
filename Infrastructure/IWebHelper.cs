
namespace Infrastructure
{
    using System.Net;

    /// <summary>
    /// Helper for retrieve request and response.
    /// </summary>
    public interface IWebHelper
    {
        /// <summary>
        /// Gets instance of <see cref="System.Net.WebRequest"/>.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Initialized <see cref="System.Net.WebRequest"/>.</returns>
        WebRequest GetRequest(string url);

        /// <summary>
        /// Gets the instance of <see cref="System.Net.WebResponse"/> from request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Response from request.</returns>
        WebResponse GetResponse(WebRequest request);
    }
}