using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

    private void Zoom_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        window.Height = 700;
        window.Width = 1000;

        window.Height = window.Height * double.Parse(Zoom.SelectedItem.ToString())! / 100!;
        window.Width = window.Width * double.Parse(Zoom.SelectedItem.ToString())! / 100;
    }

    private void Left_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;

        switch (btn!.Name)
        {
            case "Right":
                Textbox.Document.TextAlignment = TextAlignment.Right;
                break;
            case "Center":
                Textbox.Document.TextAlignment = TextAlignment.Center;
                break;
            case "Justify":
                Textbox.Document.TextAlignment = TextAlignment.Justify;
                break;
            default:
                Textbox.Document.TextAlignment = TextAlignment.Left;
                break;
        }
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

    private void Bold_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as ToggleButton;

        if (btn.IsChecked == true)
        {
            btn.Foreground = new SolidColorBrush(Colors.Red);
            switch (btn!.Name)
            {
                case "Bold":
                    // Textbox.FontWeight = FontWeights.Bold;
                    Textbox.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
                    break;
                case "Italic":
                    // Textbox.FontStyle = FontStyles.Italic;
                    Textbox.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
                    break;
                case "Ulderline":
                    Textbox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
                    break;
                default:
                    break;
            }
        }
        else
        {
            // Textbox.FontWeight = FontWeights.Normal;
            // Textbox.FontStyle = FontStyles.Normal;
            btn.Foreground = new SolidColorBrush(Colors.Black);
            Textbox.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Normal);
            Textbox.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Normal);
            Textbox.Selection.ApplyPropertyValue(Underline.TextDecorationsProperty, TextDecorations.Baseline);
        }
    }

    private void Undo_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        switch (btn!.Name)
        {
            case "Undo":
                Textbox.Undo();
                break;
            case "Redo":
                Textbox.Redo();
                break;
            default:
                break;
        }
    }

}