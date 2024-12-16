namespace LogsAggregatorApis.DataAccessLayer.GenericDbRepositoryAbstraction
{
    /// <summary>
    /// A generic repository interface for performing basic CRUD (Create, Read, Update, Delete) operations on a specific data store entity.
    /// </summary>
    /// <typeparam name="T">The type of the target entity. Must be a reference type.</typeparam>
    public interface IGenericDbRepository<T> where T : class
    {

        /// <summary>
        /// Asynchronously retrieves all entities of type <typeparamref name="T"/> from the data store.
        /// </summary>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a list of all entities of type <typeparamref name="T"/>.</returns>
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously retrieves a specific entity of type <typeparamref name="T"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to retrieve.</param>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the entity if found, or null if no such entity exists.</returns>
        Task<T?> GetAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously adds a new entity of type <typeparamref name="T"/> to the data store.
        /// </summary>
        /// <param name="newEntity">The new entity to add.</param>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CreateAsync(T newEntity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously adds multiple entities of type <typeparamref name="T"/> to the data store.
        /// </summary>
        /// <param name="newEntities">The collection of entities to add.</param>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CreateRangeAsync(IEnumerable<T> newEntities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously updates an existing entity of type <typeparamref name="T"/> in the data store by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to update.</param>
        /// <param name="updatedEntity">The entity with updated values.</param>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(string id, T updatedEntity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously removes an entity of type <typeparamref name="T"/> from the data store by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to remove.</param>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task RemoveAsync(string id, CancellationToken cancellationToken = default);
    }
}
