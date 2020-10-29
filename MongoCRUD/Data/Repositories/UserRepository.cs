using MongoCRUD.Data.Entities;

namespace MongoCRUD.Data.Repositories
{
    public class UserRepository : MongoRepository<User>
    {
        public UserRepository(string mongoDBConnectionString, string dbName, string collectionName) : base(mongoDBConnectionString, dbName, collectionName)
        {

        }
    }
}
