using System.Collections.Generic;

namespace Task_003.Calculator.Tokens;

public class Parentheses : ICalculatorToken
{
    public string Token { get; private set; }

    public Parentheses(bool closingParentheses = false) => Token = closingParentheses ? ")" : "(";

    public double TokenValue => 0;

    public int Counter { get; private set; } = 0;

    public void CountUsage() => Counter++;

    public bool IsOperationWithPriority() => true;

    public override string ToString() => Token;

    public static (int indexOfOpen, int indexOfClosing)[] 
        FindAllParanthesesPairPositions(List<ICalculatorToken> tokens)
    {
        List<(int, int)> positions = new();

        if (tokens.Count == 0) return positions.ToArray();

        int j = tokens.Count - 1;
        for (int i = 0; i <= j; i++)
        {
            if (tokens[i] is Parentheses)
            {               
                while (tokens[j] is Parentheses == false)
                {
                    j--;
                }
                if (tokens[j] is Parentheses)
                {
                    positions.Add((i, j));
                    j--;
                }
            }            
        }
        return positions.ToArray();
    }

    public static void RemoveParanthesesFromStartAndEndToHaveExpressionOnly(List<ICalculatorToken> tokens)
    {
        tokens.RemoveAt(0);
        tokens.RemoveAt(tokens.Count - 1);
    }
}
