using System.ComponentModel;

namespace MyCoins.ViewModels
{
    internal class IssuersViewModel : IIssuersViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Services.IDataService service;
        private IList<Models.Issuer> issuers = new List<Models.Issuer>();

        public IssuersViewModel(Services.IDataService service)
        {
            this.service = service;
            Dispatcher.GetForCurrentThread().Dispatch(async () =>
            {
                Issuers = await service.GetIssuersAsync();
            });
        }

        public async Task ReloadAsync()
        {
            await service.ReloadAsync();
        }

        public IList<Models.Issuer> Issuers
        {
            get
            {
                return issuers;
            }
            set
            {
                issuers = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Issuers)));
            }
        }
    }
}
