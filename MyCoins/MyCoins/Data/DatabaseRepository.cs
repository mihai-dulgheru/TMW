using MyCoins.Models;
using SQLite;

namespace MyCoins.Data
{
    internal class DatabaseRepository : IRepository
    {
        const string name = "MyCoins.db";
        SQLiteAsyncConnection connection;

        private async Task Initialize()
        {
            if (connection is null)
            {
                var path = Path.Combine(FileSystem.AppDataDirectory, name);
                var flags = SQLite.SQLiteOpenFlags.ReadWrite
                    | SQLite.SQLiteOpenFlags.Create
                    | SQLite.SQLiteOpenFlags.SharedCache;
                connection = new SQLiteAsyncConnection(path, flags);
                await connection.CreateTableAsync<Models.Coin>();
            }
        }

        public async Task<IList<Coin>> GetCoinsByIssuerAsync(Issuer issuer)
        {
            await Initialize();
            return await connection.Table<Models.Coin>()
                .Where(coin => coin.Issue == issuer.Name)
                .OrderBy(coin => coin.Issue)
                .ToListAsync();
        }

        public async Task<IList<Issuer>> GetIssuersAsync()
        {
            await Initialize();
            return await connection.QueryAsync<Models.Issuer>(
                "SELECT DISTINCT [Issuer] as [Name] FROM [Coin] ORDER BY [Issuer]");
        }

        public async Task SaveCoinsAsync(IList<Coin> coins)
        {
            await Initialize();
            await connection.DeleteAllAsync<Models.Coin>();
            await connection.InsertAllAsync(coins);
        }
    }
}
