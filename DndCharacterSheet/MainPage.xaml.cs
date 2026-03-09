namespace DndCharacterSheet
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageView _mainPageView = new MainPageView();
        private readonly BioPageView _BioPageView = new BioPageView();
        private int _cliqueCount = 0;

        public MainPage()
        {
            InitializeComponent();

            PageContainer.Content = _mainPageView;
        }

        private async void OnSelected(object sender, EventArgs e)
        {
            if (sender is Picker picker && picker.SelectedIndex != -1)
            {
                string? opcao = null;
                if (picker.ItemsSource is System.Collections.IList list)
                {
                    opcao = list[picker.SelectedIndex]?.ToString();
                }
                else
                {
                    opcao = picker.SelectedItem?.ToString();
                }
            }
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            _cliqueCount++;
            if (_cliqueCount % 2 == 0)
            {
                PageContainer.Content = _mainPageView;
            }
            else if (_cliqueCount % 2 != 0)
            {
                PageContainer.Content = _BioPageView;
            }
        }
    }
}
