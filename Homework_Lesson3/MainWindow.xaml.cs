using System.Reflection;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Homework_Lesson3;

public partial class MainWindow : Window
{

    private Color _textColor { get; set; }
    private Color _backColor { get; set; }


    public MainWindow()
    {
        InitializeComponent();
        FontSizeAdd();
        ZoomAdd();
    }












    private void FontSize_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (Textbox.Selection.IsEmpty)
            Textbox.FontSize = double.Parse(FontSize_combo.SelectedItem.ToString()!);
        else
            Textbox.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, FontSize_combo.SelectedItem.ToString());
    }

    private void FontFamily_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    => Textbox.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, FontFamily.SelectedItem.ToString());

    private void TextColor_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        _textColor = (Color)(TextColor.SelectedItem as PropertyInfo)!.GetValue(null, null)!;
        Textbox.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(_textColor));
    }

    private void BackColor_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        _backColor = (Color)(BackColor.SelectedItem as PropertyInfo)!.GetValue(null, null)!;
        Textbox.Background = new SolidColorBrush(_backColor);
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
                FontSize_combo.Items.Add(i);
        }
    }


}