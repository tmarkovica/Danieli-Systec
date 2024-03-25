﻿using System.Windows;
using System.Windows.Controls;

namespace Task_003;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly Calculator _calculator;

    public MainWindow()
    {
        InitializeComponent();
        _calculator = new();
    }

    private void UpdateResultTextBox()
    {
        //TextBoxResult.Text = _calculator.Result;
        LabelResult.Content = _calculator.Result;

        LabelStatement.Content = _calculator.MathStatement();
    }

    private void CalculatorNumberButton_Click(object sender, RoutedEventArgs e)
    {
        _calculator.NumberInput(((Button)sender).Content.ToString()!);
        UpdateResultTextBox();
    }

    private void ButtonClear_Click(object sender, RoutedEventArgs e)
    {
        _calculator.Reset();
        UpdateResultTextBox();
    }

    private void CalculatorOperationButton_Click(object sender, RoutedEventArgs e)
    {
        _calculator.SetOperation(((Button)sender).Content.ToString()![0]);
        UpdateResultTextBox();
    }

    private void CalculatorResultButton_Click(object sender, RoutedEventArgs e)
    {
        _calculator.CalculateResult();
        UpdateResultTextBox();
    }

    private void CalculatorDecimalPointButton_Click(object sender, RoutedEventArgs e)
    {
        _calculator.PutDecimalPoint();
    }
}