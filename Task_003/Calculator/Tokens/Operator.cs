namespace Task_003.Calculator.Tokens;

/// <summary>
/// <see cref="Operator"/> is representation of a arithmetic operator: '+', '-', '*' or '/'.
/// </summary>
public class Operator : ICalculatorToken
{
    public const string NO_OPERATION = " ";

    public string Token { get; private set; } = NO_OPERATION;

    public double TokenValue { get; } = 0;

    public Operator(char operation)
    {
        Token = operation.ToString();
    }

    public override string ToString() => Token;

    public bool IsOperationWithPriority() => Token == "*" || Token == "/";

    public static double Result(Operand o1, Operand o2, Operator operation)
    {
        string op = operation.Token;
        if (op == "+") return o1 + o2;
        else if (op == "-") return o1 - o2;
        else if (op == "*") return o1 * o2;
        else if (op == "/") return o1 / o2;
        else return 0;
    }
}
