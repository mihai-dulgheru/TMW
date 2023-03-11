namespace SearchName.Services
{
    public interface IDataService
    {
        Task<IList<Models.Result>> GetResultsByName(string name);
    }
}
