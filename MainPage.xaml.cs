using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Diagnostics;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
    bool isRandom;
    string hexValue;

    public MainPage()
    {
        InitializeComponent();
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (!isRandom)
        {
            double red = sldRed.Value;
            double green = sldGreen.Value;
            double blue = sldBlue.Value;
            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);
        }
    }

    private void SetColor(Color color)
    {
        Debug.WriteLine(color.ToString());
        btnRandom.BackgroundColor = color;
        Container.BackgroundColor = color;
        hexValue = color.ToHex();
        lblHex.Text = hexValue;
    }

    private void btnRandom_Clicked(object sender, EventArgs e)
    {
        isRandom = true;
        Random random = new Random();
        Color color = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        SetColor(color);
        sldRed.Value = color.Red;
        sldGreen.Value = color.Green;
        sldBlue.Value = color.Blue;
        isRandom = false;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(hexValue);
        IToast toast = Toast.Make("Color copied", ToastDuration.Short, 12);
        await toast.Show();
    }
}
