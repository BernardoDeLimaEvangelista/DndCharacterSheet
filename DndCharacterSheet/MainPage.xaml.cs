namespace DndCharacterSheet
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSelected(object sender, EventArgs e)
        {
            if (sender is Picker picker && picker.SelectedIndex != -1)
            {
                string? raca = null;
                if (picker.ItemsSource is System.Collections.IList list)
                {
                    raca = list[picker.SelectedIndex]?.ToString();
                }
                else
                {
                    raca = picker.SelectedItem?.ToString();
                }

                if (raca != null)
                {
                    await DisplayAlertAsync("Ficha", $"Raça {raca} selecionada!", "OK");
                }
            }
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlertAsync("Funcionou!", "Botão Clicado e funcionando!", "OK");
        }
    }
}
