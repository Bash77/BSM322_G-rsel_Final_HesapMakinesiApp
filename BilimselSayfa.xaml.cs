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

        // Giriş temizleme
        private void OnClearClicked(object sender, EventArgs e)
        {
            BilimselEntry.Text = "";
        }

        // Eşittir tuşu (şu an kullanılmıyor, istenirse hesaplama mantığı eklenebilir)
        private void OnEqualClicked(object sender, EventArgs e)
        {
            // Gerekirse gelecekte işlem eklenecek
        }

        // Karekök
        private async void OnSqrtClicked(object sender, EventArgs e)
        {
            if (await TryParseInput())
                BilimselEntry.Text = Math.Sqrt(sayi).ToString();
        }

        // Üs alma (xʸ)
        private async void OnPowerClicked(object sender, EventArgs e)
        {
            string giris = await DisplayPromptAsync("Üs İşlemi", "Üssü girin (y):", keyboard: Keyboard.Numeric);
            if (await TryParseInput() && double.TryParse(giris, out double us))
                BilimselEntry.Text = Math.Pow(sayi, us).ToString();
        }

        // e^x
        private async void OnExpClicked(object sender, EventArgs e)
        {
            if (await TryParseInput())
                BilimselEntry.Text = Math.Exp(sayi).ToString();
        }

        // ln(x)
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

        // log10(x)
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

        // sin(x)
        private async void OnSinClicked(object sender, EventArgs e)
        {
            if (await TryParseInput())
                BilimselEntry.Text = Math.Sin(DereceToRadyan(sayi)).ToString();
        }

        // cos(x)
        private async void OnCosClicked(object sender, EventArgs e)
        {
            if (await TryParseInput())
                BilimselEntry.Text = Math.Cos(DereceToRadyan(sayi)).ToString();
        }

        // tan(x)
        private async void OnTanClicked(object sender, EventArgs e)
        {
            if (await TryParseInput())
                BilimselEntry.Text = Math.Tan(DereceToRadyan(sayi)).ToString();
        }

        // π butonu
        private void OnPiClicked(object sender, EventArgs e)
        {
            BilimselEntry.Text = Math.PI.ToString();
        }

        // e sabiti
        private void OnEClicked(object sender, EventArgs e)
        {
            BilimselEntry.Text = Math.E.ToString();
        }

        // Sayı kontrolü ve geçersiz girişte uyarı
        private async Task<bool> TryParseInput()
        {
            if (double.TryParse(BilimselEntry.Text, out sayi))
                return true;

            await DisplayAlert("Hata", "Geçerli bir sayı girin.", "Tamam");
            return false;
        }

        // Derece -> Radyan dönüşümü
        private double DereceToRadyan(double derece)
        {
            return (Math.PI / 180) * derece;
        }
    }
}
