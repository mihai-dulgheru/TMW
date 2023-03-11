namespace MyCoins.Views;

//[QueryProperty()]
public partial class CoinsByIssuerPage : ContentPage, IQueryAttributable
{
    public CoinsByIssuerPage(ViewModels.CoinsByIssuerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    internal Models.Issuer Issuer
    {
        set
        {
            (BindingContext as ViewModels.ICoinsByIssuerViewModel).Issuer = value;
            Title = $"Coins of {value.Name}";
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Issuer = query["Issuer"] as Models.Issuer;
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//issuers");
    }
}