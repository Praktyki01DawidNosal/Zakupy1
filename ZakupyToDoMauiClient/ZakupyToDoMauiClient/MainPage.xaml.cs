using System.Diagnostics;
using ToDoMauiClient.DataServices;

namespace ZakupyToDoMauiClient
{
    public partial class MainPage : ContentPage
    {
        private readonly IRestDataService _datService;

        public MainPage(IRestDataService dataService)
        {
            InitializeComponent();

            _datService = dataService;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //collectionView.ItemsSource = await _datService.GetAllToDosAsync();
        }

        async void OnAddZakupyToDoClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("---> Add button clicked");
        }
        async void OnSelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {
            Debug.WriteLine("---> Item Changed clicked");
        }
    }
}
