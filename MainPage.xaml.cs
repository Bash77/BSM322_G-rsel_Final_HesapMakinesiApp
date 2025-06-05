using System;

namespace HesapMakinesiApp
{
    public partial class MainPage : ContentPage
    {
        double sayi1 = 0;
        string secilenIslem = "";

        public MainPage()
        {
            InitializeComponent();
        }

        // Sayı tuşlarına basıldığında çalışır
        private void OnDigitClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            EntryGiris.Text += btn.Text;
        }

        // İşlem tuşlarına basıldığında çalışır (+, -, ×, ÷)
        private async void OnOperatorClicked(object sender, EventArgs e)  // ✅ async eklendi
        {
            try
            {
                sayi1 = double.Parse(EntryGiris.Text);
                Button btn = (Button)sender;
                secilenIslem = btn.Text;
                EntryGiris.Text = ""; // yeni sayı girilecek
            }
            catch
            {
                await DisplayAlert("Hata", "Geçerli bir sayı giriniz.", "Tamam"); // ✅ virgül düzeltildi
                EntryGiris.Text = "";
            }
        }

        // "=" tuşuna basıldığında sonucu hesaplar
        private async void OnEqualClicked(object sender, EventArgs e)
        {
            try
            {
                double sayi2 = double.Parse(EntryGiris.Text);
                double sonuc = 0;

                switch (secilenIslem)
                {
                    case "+":
                        sonuc = sayi1 + sayi2;
                        break;
                    case "-":
                        sonuc = sayi1 - sayi2;
                        break;
                    case "×":
                        sonuc = sayi1 * sayi2;
                        break;
                    case "÷":
                        if (sayi2 == 0)
                        {
                            await DisplayAlert("Hata", "Sıfıra bölme hatası!", "Tamam");
                            return;
                        }
                        sonuc = sayi1 / sayi2;
                        break;
                }

                EntrySonuc.Text = sonuc.ToString();
                EntryGiris.Text = "";
            }
            catch
            {
                await DisplayAlert("Hata", "İşlem yapılırken hata oluştu.", "Tamam");
            }
        }

        // "C" (Clear) butonu
        private void OnClearClicked(object sender, EventArgs e)
        {
            EntryGiris.Text = "";
            EntrySonuc.Text = "";
            sayi1 = 0;
            secilenIslem = "";
        }
    }
}
