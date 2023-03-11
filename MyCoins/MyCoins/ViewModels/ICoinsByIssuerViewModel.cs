using System.ComponentModel;

namespace MyCoins.ViewModels
{
    public interface ICoinsByIssuerViewModel : INotifyPropertyChanged
    {
        Models.Issuer Issuer { set; }
        IList<Models.Coin> Coins { get; }
    }
}
