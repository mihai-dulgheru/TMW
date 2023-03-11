namespace MyCoins.Data
{
    internal interface IRepository
    {
        Task<IList<Models.Issuer>> GetIssuersAsync();

        Task<IList<Models.Coin>> GetCoinsByIssuerAsync(Models.Issuer issuer);

        Task SaveCoinsAsync(IList<Models.Coin> coins);
    }
}
