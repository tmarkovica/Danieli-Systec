namespace Task_003.Calculator.Tokens;

/// <summary>
/// <see cref="Operand"/> is representation of a number.
/// </summary>
public class Operand : ICalculatorToken
{
    public double TokenValue
    {
        get => double.Parse(Token);
        private set => Token = value.ToString();
    }

    public string Token { get; private set; } = "0";

    public Operand() { }

    public Operand(double value) { TokenValue = value; }

    public void AppendDigit(string digit)
    {
        if (Token == "0")
            Token = digit;
        else
            Token += digit;
    }

    public void SetNumber(double number) => Token = number.ToString();

    public void AddDecimalPoint()
    {
        if (Token.Contains(',') == false)
            Token += ",";
    }

    public override string ToString() => Token;

    public static double operator +(Operand n1, Operand n2) => n1.TokenValue + n2.TokenValue;
    public static double operator -(Operand n1, Operand n2) => n1.TokenValue - n2.TokenValue;
    public static double operator *(Operand n1, Operand n2) => n1.TokenValue * n2.TokenValue;
    public static double operator /(Operand n1, Operand n2) => n1.TokenValue / n2.TokenValue;

    public bool IsOperationWithPriority() => false;
}