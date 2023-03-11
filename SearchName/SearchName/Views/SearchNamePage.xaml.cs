namespace SearchName.Views;

public partial class SearchNamePage : ContentPage
{
    public SearchNamePage(ViewModels.ISearchNameViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void ExitToolbarItem_Clicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }

    private void NameEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        (BindingContext as ViewModels.ISearchNameViewModel).ClearResults();
    }

    private void SearchButton_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ViewModels.ISearchNameViewModel).SearchName();
    }
}