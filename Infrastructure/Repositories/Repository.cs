

namespace Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Class Repository holds <see cref="Infrastructure.IRepository{T}" /> entities to work with them.
    /// </summary>
    /// <typeparam name="T"><see cref="Infrastructure.IRepository{T}" />Base entity.</typeparam>
    /// <seealso cref="CleanApiCore.IRepository{T}" />
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// The default API URL from where entities are downloaded.
        /// </summary>
        private const string Api = "https://swapi.dev/api/";
        /// <summary>
        /// The URL end character. By default is "/" slash.
        /// </summary>
        private string urlEndCharacter = "/";

        /// <summary>
        /// The URL data that will be used in data service.
        /// </summary>
        private string urlData;

        /// <summary>
        /// The data service for entities.
        /// </summary>
        private IDataService dataService;

        /// <summary>
        /// The base entity.
        /// <seealso cref="Infrastructure.BaseEntity" />
        /// </summary>
        private T entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}" /> class.
        /// Uses the default data service and URL for gather data.
        /// </summary>
        public Repository()
            : this(new DefaultDataService(new WebHelper()), Api)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class. Uses a default URL for gather data.
        /// </summary>
        /// <param name="dataService">The data service to get entities.</param>
        /// <example>Data service getting data from JSON document, other database etc.</example>
        public Repository(IDataService dataService)
            : this(dataService, Api)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="dataService">The data service to get entities.</param>
        /// <param name="url">The URL for consuming. It will be used in the service. Examples: http://mySite.com, http://mySite.com/ .</param>
        /// <example>Data service getting data from JSON document, other database etc.</example>
        public Repository(IDataService dataService, string url)
        {
            this.entity = HelperInitializer<T>.Instance();
            this.dataService = dataService;

            if (!url.EndsWith(this.urlEndCharacter))
            {
                url += this.urlEndCharacter;
            }

            this.urlData = url;
        }
        

        /// <summary>
        /// Gets the entity by it's identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns><see cref="Infrastructure.IRepository{T}" /></returns>
        public T GetById(int id)
        {
            string url = $"{this.urlData}{this.entity.GetPath()}{id}";
            string jsonResponse = this.dataService.GetDataResult(url);
            if (jsonResponse == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }       

    }}
