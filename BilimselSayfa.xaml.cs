using System;

namespace HesapMakinesiApp
{
    public partial class BilimselSayfa : ContentPage
    {
        double sayi = 0;

        public BilimselSayfa()
        {
            InitializeComponent();
        }

      
        private void OnClearClicked(object sender, EventArgs e)
        {
            BilimselEntry.Text = "";
        }

         
        private void OnEqualClicked(object sender, EventArgs e)
        {
             
        }

       
        private async void OnSqrtClicked(object sender, EventArgs e)
        {
            if (await TryParseInput())
                BilimselEntry.Text = Math.Sqrt(sayi).ToString();
        }

        
        private async void OnPowerClicked(object sender, EventArgs e)
        {
            string giris = await DisplayPromptAsync("Üs İşlemi", "Üssü girin (y):", keyboard: Keyboard.Numeric);
            if (await TryParseInput() && double.TryParse(giris, out double us))
                BilimselEntry.Text = Math.Pow(sayi, us).ToString();
        }

       
        private async void OnExpClicked(object sender, EventArgs e)
        {
            if (await TryParseInput())
                BilimselEntry.Text = Math.Exp(sayi).ToString();
        }

        
        private async void OnLnClicked(object sender, EventArgs e)
        {
            if (await TryParseInput())
            {
                if (sayi <= 0)
                    await DisplayAlert("Hata", "Doğal logaritma yalnızca pozitif sayılar için tanımlıdır.", "Tamam");
                else
                    BilimselEntry.Text = Math.Log(sayi).ToString();
            }
        }

        
        private async void OnLogClicked(object sender, EventArgs e)
        {
            if (await TryParseInput())
            {
                if (sayi <= 0)
                    await DisplayAlert("Hata", "Logaritma yalnızca pozitif sayılar için tanımlıdır.", "Tamam");
                else
                    BilimselEntry.Text = Math.Log10(sayi).ToString();
            }
        }

      
        private async void OnSinClicked(object sender, EventArgs e)
        {
            if (await TryParseInput())
                BilimselEntry.Text = Math.Sin(DereceToRadyan(sayi)).ToString();
        }

        
        private async void OnCosClicked(object sender, EventArgs e)
        {
            if (await TryParseInput())
                BilimselEntry.Text = Math.Cos(DereceToRadyan(sayi)).ToString();
        }

        
        private async void OnTanClicked(object sender, EventArgs e)
        {
            if (await TryParseInput())
                BilimselEntry.Text = Math.Tan(DereceToRadyan(sayi)).ToString();
        }

        
        private void OnPiClicked(object sender, EventArgs e)
        {
            BilimselEntry.Text = Math.PI.ToString();
        }

        
        private void OnEClicked(object sender, EventArgs e)
        {
            BilimselEntry.Text = Math.E.ToString();
        }

        
        private async Task<bool> TryParseInput()
        {
            if (double.TryParse(BilimselEntry.Text, out sayi))
                return true;

            await DisplayAlert("Hata", "Geçerli bir sayı girin.", "Tamam");
            return false;
        }

       
        private double DereceToRadyan(double derece)
        {
            return (Math.PI / 180) * derece;
        }
    }
}
