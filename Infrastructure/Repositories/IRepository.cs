﻿
namespace Infrastructure
{
    using Domain.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Interface IRepository
    /// </summary>
    /// <typeparam name="T"><see cref="CleanApiCore.BaseEntity" />Base entity.</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets the entity by it's identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="CleanApiCore.BaseEntity" />Base entity.</returns>
        T GetById(int id);

        /// <summary>
        /// Gets entities.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="size">The size of entities.</param>
        /// <returns>ICollection&lt; <see cref="CleanApiCore.BaseEntity" /> &gt;.</returns>
        ICollection<T> GetEntities(int page = 1, int size = 10);
    }
}