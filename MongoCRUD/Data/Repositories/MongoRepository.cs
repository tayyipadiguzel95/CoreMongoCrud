using MongoCRUD.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoCRUD.Data.Repositories
{
    public class MongoRepository<TModel> where TModel : MongoBaseModel
    {
        private readonly IMongoCollection<TModel> _mongoCollection;

        public MongoRepository(string mongoDBConnectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(mongoDBConnectionString);
            var database = client.GetDatabase(dbName);
            _mongoCollection = database.GetCollection<TModel>(collectionName);
        }

        public virtual async Task<List<TModel>> GetAllAsync()
        {
            return await _mongoCollection.Find(a => true).ToListAsync();
        }

        public async Task<TModel> GetByIdAsync(string id)
        {
            var docId = new ObjectId(id);
            return await _mongoCollection.Find(a => a.Id == docId).FirstOrDefaultAsync();
        }

        public async Task<TModel> InsertAsync(TModel document)
        {
            await _mongoCollection.InsertOneAsync(document);
            return document;
        }

        public async Task<TModel> UpdateAsync(string id, TModel document)
        {
            var docId = new ObjectId(id);
            await _mongoCollection.ReplaceOneAsync(m => m.Id == docId, document);
            return document;
        }

        public async Task DeleteAsync(string id)
        {
            var docId = new ObjectId(id);
            var doc = await GetByIdAsync(id);
            doc.IsDeleted = true;
            await _mongoCollection.ReplaceOneAsync(m => m.Id == docId, doc);
        }
    }
}
