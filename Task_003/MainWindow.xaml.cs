using System.Windows;
using System.Windows.Controls;

namespace Task_003;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CalculatorNumberButton_Click(object sender, RoutedEventArgs e)
    {
        if (TextBoxResult.Text == "0")
            TextBoxResult.Text = "";
        TextBoxResult.Text += ((Button)sender).Content.ToString();
    }

    private void ButtonClear_Click(object sender, RoutedEventArgs e)
    {
        TextBoxResult.Text = "0";
    }
}