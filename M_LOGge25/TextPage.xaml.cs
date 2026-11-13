using System.Collections;

namespace M_LOGge25;

public partial class TextPage : ContentPage
{
    Label lbl;
    Editor editor;
    HorizontalStackLayout hst; // Horisontaalne paigutus nuppude jaoks
    VerticalStackLayout vst; // Vertikaalne paigutus lehe sisu jaoks
    List<string> nupud = new List<string>() { "Tagasi", "Avalehele", "Edasi", "Räägi" };
    public TextPage()
	{
		lbl = new Label
        {
            Text = "See on tekstileht",
            FontSize = 30,
            TextColor = Colors.Blue,
            HorizontalOptions = LayoutOptions.Center//justimeerib horisontaalselt keskele
        };
        editor= new Editor
        {
            Placeholder = "Sisesta tekst siia...",
            AutoSize = EditorAutoSizeOption.TextChanges,
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            FontSize = 20,
            Keyboard = Keyboard.Chat
        };
        editor.TextChanged +=(sender, e) =>
        {
            lbl.Text = editor.Text;
        };
        hst=new HorizontalStackLayout { Spacing=10 };

        for (int i = 0; i < nupud.Count; i++)
        {
            Button nupp = new Button
            {
                Text = nupud[i],
                FontSize = 20,
                BackgroundColor = Colors.LightBlue,
                TextColor = Colors.Blue,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 30,
                HeightRequest = 50,
                ZIndex = i
            };
            hst.Children.Add(nupp);
            nupp.Clicked += Nupp_Clicked;
        }
        

        vst = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 10,
            Children = { lbl, editor,hst }
        };
        Content= vst;
    }

    private void Nupp_Clicked(object? sender, EventArgs e)
    {
        Button nupp= sender as Button;
        if (nupp.ZIndex==0)
        {
            Navigation.PopAsync();// Tagasi eelmisele lehele
        }
        else if (nupp.ZIndex==1)
        {
            Navigation.PopToRootAsync();// Tagasi avalehele
        }
        else if (nupp.ZIndex==2)
        {
            Navigation.PushAsync(new FigurePage());
        }
        else if (nupp.ZIndex==3)
        {
            Raagi(sender, e);
        }
    }

    private async void Raagi(object? sender, EventArgs e)
    {
        IEnumerable<Locale> locales = await TextToSpeech.Default.GetLocalesAsync();
        SpeechOptions options = new SpeechOptions()
        {
            Volume = 1.0f,
            Pitch = 1.0f,
            Locale = locales.FirstOrDefault(l => l.Language.StartsWith("et")) // Võtab esimese saadaval oleva keele
        };
        var tekst= editor.Text;
        if(string.IsNullOrWhiteSpace(tekst))
        {
            await DisplayAlertAsync("Hoiatus", "Tekst on tühi!", "OK");
            return;
        }
        try
        {
            await TextToSpeech.Default.SpeakAsync(tekst, options);

        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Viga", $"Teksti kõneks muutmine ebaõnnestus: {ex.Message}", "OK");
        }
    }
}