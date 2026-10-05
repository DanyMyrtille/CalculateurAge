using CalculateurAge.ViewModels;

namespace CalculateurAge;

public partial class ResultPage : ContentPage
{
    public ResultPage(ResultViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
