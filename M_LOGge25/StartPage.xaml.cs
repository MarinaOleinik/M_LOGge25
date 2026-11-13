namespace M_LOGge25;

public partial class StartPage : ContentPage
{
	VerticalStackLayout vst;
	public List<ContentPage> Lehed= new List<ContentPage>() { new MainPage(), new TextPage(),new FigurePage() };
	public List<string> LehedNimed = new List<string>() { "MainPage", "TextPage", "FigurePage" };
    public StartPage()
	{
		//InitializeComponent();
		vst= new VerticalStackLayout { Padding=20, Spacing=10 };
        for (int i = 0; i < Lehed.Count; i++)
        {
            Button nupp = new Button
            {
                 Text = LehedNimed[i],
                 FontSize=40,
                 BackgroundColor=Colors.LightBlue,
                 TextColor=Colors.Blue,
                 FontAttributes=FontAttributes.Bold,
                 CornerRadius=30,
                 HeightRequest=100,
                 ZIndex=i
            };
            nupp.Clicked +=  (sender, e) =>
            {

                 Navigation.PushAsync(Lehed[nupp.ZIndex]);
            };


            vst.Add(nupp);
        }
        
        Content = vst;
    }
}