namespace MyCoins.Services
{
    public interface IDataService
    {
        Task<IList<Models.Issuer>> GetIssuersAsync();

        Task<IList<Models.Coin>> GetCoinsByIssuerAsync(Models.Issuer issuer);

        Task ReloadAsync();
    }
}
