namespace MyCoins.Views;

public partial class IssuersPage : ContentPage
{
    public IssuersPage(ViewModels.IIssuersViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await (BindingContext as ViewModels.IIssuersViewModel).ReloadAsync();
    }

    async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var issuer = e.SelectedItem as Models.Issuer;
        var parameters = new Dictionary<string, object>();
        parameters["Issuer"] = issuer;
        await Shell.Current.GoToAsync("//coinsByIssuer", parameters);
    }
}