namespace Task_003.Calculator.Tokens;

/// <summary>
/// Word token refers to either numbers (operands) or operators in a calculator 
/// or mathematical expression.
/// For example, in the expression "3 + 5 * 2", the tokens are "3", "+", "5", "*", and "2".
/// </summary>
public interface ICalculatorToken
{
    public string Token { get; }
    public double TokenValue { get; }
    public string ToString();
    public bool IsOperationWithPriority();
}
