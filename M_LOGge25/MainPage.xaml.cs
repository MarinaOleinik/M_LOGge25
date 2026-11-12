namespace M_LOGge25
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";
            // Loogika 2: Pööra pilti iga vajutusega 15 kraadi
            BotImage.Rotation += 15;

            // Loogika 3: Muuda Labeli teksti
            CounterLabel.Text = $"Nuppu on vajutatud kokku: {count}";
            SemanticScreenReader.Announce(CounterBtn.Text);

            // Genereerime juhusliku värvi (R, G, B)
            var random = new Random();
            var randomColor = Color.FromRgb(
                random.Next(0, 256), // Red
                random.Next(0, 256), // Green
                random.Next(0, 256)  // Blue
            );

            // Rakendame värvi teisele nupule või taustale
            ResetBtn.BackgroundColor = randomColor;
            if (count >= 10)
            {
                BotImage.IsVisible = false; // Peidab pildi
                CounterLabel.Text = "Pilt kadus ära! Vajuta Reset.";
            }
            // Kui loendur on 5 või rohkem, muuda nupu värvi
            if (count >= 5)
            {
                CounterBtn.BackgroundColor = Colors.Red;
                CounterBtn.TextColor = Colors.White;
            }
        }

        private void CounterBtn1_Clicked(object sender, EventArgs e)
        {
            count--;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        // UUS MEETOD: Reset nupu jaoks
        private void ResetBtn_Clicked(object sender, EventArgs e)
        {
            count = 0;
            CounterBtn.Text = "Vajuta mind";
            CounterLabel.Text = "Alustame uuesti!";
            BotImage.Rotation = 0; // Pilt läheb otseks tagasi
            BotImage.IsVisible = true; // Toob pildi tagasi
            ResetBtn.ClearValue(BackgroundColorProperty);// eemaldab reset nupu taustavärvi
            CounterBtn.ClearValue(BackgroundColorProperty);// eemaldab counter nupu taustavärvi
            CounterBtn.ClearValue(Button.TextColorProperty);// eemaldab counter nupu tekstivärvi
                                                            // Liigutame pildi paremasse serva
            

            // VÕI teeme loogika: kui on vasakul, liiguta paremale, ja vastupidi
            if (BotImage.HorizontalOptions == LayoutOptions.Start)
            {
                BotImage.HorizontalOptions = LayoutOptions.End;
            }
            else
            {
                BotImage.HorizontalOptions = LayoutOptions.Start;
            }
            if (BotImage.VerticalOptions == LayoutOptions.Start)
            {
                BotImage.VerticalOptions    = LayoutOptions.End;
            }
            else
            {
                BotImage.VerticalOptions = LayoutOptions.Start;
            }
        }
    }
}
