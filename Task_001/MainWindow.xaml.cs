using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Task_001;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly XmasCard xmasCard = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void TextBoxRowCount_NumbersOnly(object sender, TextCompositionEventArgs e)
    {
        e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);        
    }

    private void ButtonGenerate_Click(object sender, RoutedEventArgs e)
    {
        xmasCard.Header = TextBoxHeader.Text;
        xmasCard.Footer = TextBoxFooter.Text;
        xmasCard.RowCount = int.Parse(TextBoxRowCount.Text);

        TextBlockXmasCard.Text = xmasCard.GenerateCard();
    }
}