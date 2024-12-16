using LogsAggregatorApis.DataAccessLayer.GenericDbRepositoryAbstraction;
using LogsAggregatorApis.HelperTypes.General;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace LogsAggregatorApis.DataAccessLayer
{
    public class MongoDbRepository<T> : IGenericDbRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;


        private const string Id = nameof(Id);


        public MongoDbRepository(IOptions<AppDbSettings> appDbSettings)
        {
            var mongoClient = new MongoClient(appDbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(appDbSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<T>(typeof(T).Name);
        }

       
        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _collection.Find(_ => true).ToListAsync(cancellationToken);


        public async Task<T?> GetAsync(string id, CancellationToken cancellationToken = default) =>
            await _collection.Find(BuildPredicate(Id, id)).FirstOrDefaultAsync(cancellationToken);


        public async Task CreateAsync(T newEntity, CancellationToken cancellationToken = default) =>
            await _collection.InsertOneAsync(newEntity, cancellationToken: cancellationToken);


        public async Task CreateRangeAsync(IEnumerable<T> newEntities, CancellationToken cancellationToken = default) =>
            await _collection.InsertManyAsync(newEntities, cancellationToken: cancellationToken);


        public async Task UpdateAsync(string id, T updatedEntity, CancellationToken cancellationToken = default) =>
            await _collection.ReplaceOneAsync(BuildPredicate(Id, id), updatedEntity, cancellationToken: cancellationToken);


        public async Task RemoveAsync(string id, CancellationToken cancellationToken = default) =>
            await _collection.DeleteOneAsync(BuildPredicate(Id, id), cancellationToken: cancellationToken);


        #region Helper Methods
        /// <summary>
        /// Builds a predicate expression for a given property name and value.
        /// </summary>
        /// <param name="propertyName">The name of the property to filter by.</param>
        /// <param name="value">The value to filter by.</param>
        /// <returns>The predicate expression.</returns>
        private static Expression<Func<T, bool>> BuildPredicate(string propertyName, object value)
        {
            var param = Expression.Parameter(typeof(T), "x");

            var property = Expression.Property(param, propertyName);

            var constant = Expression.Constant(value);

            var body = Expression.Equal(property, constant);

            return Expression.Lambda<Func<T, bool>>(body, param);
        }
        #endregion
    }
}
