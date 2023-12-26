
namespace Infrastructure
{
    using Domain.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Interface IRepository
    /// </summary>
    /// <typeparam name="T"><see cref="CQRSPatternWebAPI.BaseEntity" />Base entity.</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets the entity by it's identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="CQRSPatternWebAPI.BaseEntity" />Base entity.</returns>
        T GetById(int id);
        
    }
}
