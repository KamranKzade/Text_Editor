using System.Windows;

namespace Homework_Lesson3;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        FontSizeAdd();
        ZoomAdd();
    }







    private void ZoomAdd()
    {
        Zoom.Items.Add("50");
        Zoom.Items.Add("75");
        Zoom.Items.Add("100");
        Zoom.Items.Add("125");
        Zoom.Items.Add("150");
        Zoom.Items.Add("200");
    }

    private void FontSizeAdd()
    {
        for (int i = 8; i <= 72; i++)
        {
            if (i % 2 == 0)
                FontSize.Items.Add(i);
        }

        FontSize.SelectedIndex = 0;
    }
}
