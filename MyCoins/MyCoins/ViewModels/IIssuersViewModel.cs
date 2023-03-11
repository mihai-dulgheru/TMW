using System.ComponentModel;

namespace MyCoins.ViewModels
{
    public interface IIssuersViewModel : INotifyPropertyChanged
    {
        IList<Models.Issuer> Issuers { get; }

        Task ReloadAsync();
    }
}
