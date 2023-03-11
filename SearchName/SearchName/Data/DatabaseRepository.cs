using SearchName.Models;
using SQLite;

namespace SearchName.Data
{
    public class DatabaseRepository : IRepository
    {
        private SQLiteAsyncConnection connection;

        public async Task<IList<Result>> GetResultsByName(string name)
        {
            await Initialize();
            return await connection.Table<Models.Result>()
                .Where(result => result.Name.ToLower() == name.ToLower())
                .OrderByDescending(result => result.Count)
                .ToListAsync();
        }

        public async Task SaveResults(IList<Result> results)
        {
            await Initialize();
            await connection.InsertAllAsync(results);
        }

        private async Task Initialize()
        {
            if (connection is null)
            {
#pragma warning disable CA1416 // Validate platform compatibility
                connection = new SQLiteAsyncConnection(
                    Path.Combine(FileSystem.AppDataDirectory,
                        Utilities.Constants.DatabaseFile),
                        SQLiteOpenFlags.Create
                        | SQLiteOpenFlags.ReadWrite
                        | SQLiteOpenFlags.SharedCache
                    );
#pragma warning restore CA1416 // Validate platform compatibility
                await connection.CreateTableAsync<Models.Result>();
            }
        }
    }
}
