using System.Text;
using System.Windows;
using Task_003.Calculator.Tokens;

namespace Task_003.Calculator;

public class Calculator
{
    private double _Result { get; set; }

    public string Result { get => _Result.ToString(); }

    private List<ICalculatorToken> CalculatorTokens { get; set; } = new();

    private Operand RefCurrentNumber = new();

    private (Parentheses open, Parentheses closing) Parentheses = (new Parentheses(), new Parentheses(true));

    public Calculator()
    {
        Reset();
    }

    public void Reset()
    {
        _Result = 0;
        CalculatorTokens.Clear();
        RefCurrentNumber = new();
    }

    public string MathStatement()
    {
        StringBuilder sb = new();
        foreach (ICalculatorToken token in CalculatorTokens)
            sb.Append(token);
        return sb.ToString();
    }

    private void CalculateAndWithResultTokenReplace_OneOperandOnEachSideAndOperatorAtPosition(int i)
    {
        double result = Operator.Result(
                            (Operand)CalculatorTokens[i - 1],
                            (Operand)CalculatorTokens[i + 1],
                            (Operator)CalculatorTokens[i]
                        );

        CalculatorTokens.RemoveRange(i - 1, 3);
        CalculatorTokens.Insert(i - 1, new Operand(result));
    }

    private void SolveOperationsWithHigherPriority()
    {
        for (int i = 0; i < CalculatorTokens.Count; i++)
        {
            if (CalculatorTokens[i] is Operator)
            {
                if (CalculatorTokens[i].IsOperationWithPriority())
                {
                    CalculateAndWithResultTokenReplace_OneOperandOnEachSideAndOperatorAtPosition(i);
                    i -= 2;
                }
            }
        }
    }

    private void SolveOperationsWithHigherPriority(List<ICalculatorToken> tokens)
    {
        for (int i = 1; i < tokens.Count - 1; i++)
        {
            if (tokens[i] is Operator)
            {
                if (tokens[i].IsOperationWithPriority())
                {
                    double result = Operator.Result(
                            (Operand)tokens[i - 1],
                            (Operand)tokens[i + 1],
                            (Operator)tokens[i]
                        );

                    tokens.RemoveRange(i - 1, 3);
                    tokens.Insert(i - 1, new Operand(result));
                    i -= 2;
                }
            }
        }
    }

    private void SolveOperationsWithLowerPrioirty(List<ICalculatorToken> tokens)
    {
        for (int i = 0; i < tokens.Count; i++)
        {
            if (tokens[i] is Operator)
            {
                double result = Operator.Result(
                            (Operand)tokens[i - 1],
                            (Operand)tokens[i + 1],
                            (Operator)tokens[i]
                        );

                tokens.RemoveRange(i - 1, 3);
                tokens.Insert(i - 1, new Operand(result));
                i -= 2;
            }
        }
    }

    private void SolveOperationsWithLowerPrioirty()
    {
        for (int i = 0; i < CalculatorTokens.Count; i++)
        {
            if (CalculatorTokens[i] is Operator)
            {
                CalculateAndWithResultTokenReplace_OneOperandOnEachSideAndOperatorAtPosition(i);
                i -= 2;
            }
        }
    }

    private ICalculatorToken SolveExpression_GetResult(List<ICalculatorToken> tokens)
    {
        while (tokens.Count > 1)
        {
            SolveOperationsWithHigherPriority(tokens);
            SolveOperationsWithLowerPrioirty(tokens);
        }
        return tokens.First();
    }

    public void CalculateResult()
    {
        if (AreAllParenthesesClosed() == false) return;

        if (CalculatorTokens.Last() is Operator)
        {
            CalculatorTokens.Add(RefCurrentNumber);
            RefCurrentNumber = new();
        }

        (int indexOfOpen, int indexOfClosing)[] paranthesesPairs =
            Task_003.Calculator.Tokens.Parentheses.FindAllParanthesesPairPositions(CalculatorTokens);             

        for (int i = paranthesesPairs.Length - 1; i >= 0; i--)
        {
            List<ICalculatorToken> expressionWParantheses = CalculatorTokens.GetRange(
                    paranthesesPairs[i].indexOfOpen,
                    paranthesesPairs[i].indexOfClosing - paranthesesPairs[i].indexOfOpen + 1
                );

            Tokens.Parentheses.RemoveParanthesesFromStartAndEndToHaveExpressionOnly(expressionWParantheses);

            
            CalculatorTokens.RemoveRange(
                    paranthesesPairs[i].indexOfOpen,
                    paranthesesPairs[i].indexOfClosing - paranthesesPairs[i].indexOfOpen + 1
                );

            CalculatorTokens.Insert(
                paranthesesPairs[i].indexOfOpen,
                SolveExpression_GetResult(expressionWParantheses)
                );
        }

        while (CalculatorTokens.Count > 1)
        {           
            SolveOperationsWithHigherPriority();
            SolveOperationsWithLowerPrioirty();
        }

        double temp = CalculatorTokens.First().TokenValue;
        Reset();
        _Result = temp;
    }

    public void OperationInput(char operatorSymbol)
    {
        if (_Result != 0)
            CalculatorTokens.Add(RefCurrentNumber);

        CalculatorTokens.Add(new Operator(operatorSymbol));
        _Result = RefCurrentNumber.TokenValue;
        RefCurrentNumber = new();
    }

    public void DigitInput(string digit)
    {
        RefCurrentNumber.AppendDigit(digit);
        _Result = RefCurrentNumber.TokenValue;
    }

    public void DecimalPointInput()
    {
        RefCurrentNumber.AddDecimalPoint();
    }

    private bool AreAllParenthesesClosed()
    {
        return Parentheses.closing.Counter == Parentheses.open.Counter;
    }

    public void OpenParanthesis()
    {       
        if (CalculatorTokens.Count > 0)
        {
            if (CalculatorTokens.Last() is Operand)
            {
                CalculatorTokens.Add(RefCurrentNumber);
                CalculatorTokens.Add(new Operator('*'));
            }
            else if (CalculatorTokens.Last() is Operator)
            {
            }
            else if (CalculatorTokens.Last() is Tokens.Parentheses)
            {
                CalculatorTokens.Add(new Operator('*'));
            }
        }
        else
        {
            if (_Result != 0)
            {
                CalculatorTokens.Add(RefCurrentNumber);
                CalculatorTokens.Add(new Operator('*'));
            }
        }

        CalculatorTokens.Add(Parentheses.open);
        Parentheses.open.CountUsage();
        RefCurrentNumber = new();
        _Result = 0;

    }

    public void CloseParanthesis()
    {
        if (Parentheses.closing.Counter < Parentheses.open.Counter)
        {
            if (CalculatorTokens.Last() is Operator)
            {
                RefCurrentNumber.SetNumber(_Result);
            }

            CalculatorTokens.Add(RefCurrentNumber);
            CalculatorTokens.Add(Parentheses.closing);
            Parentheses.closing.CountUsage();
            RefCurrentNumber = new();
            _Result = 0;
        }
    }
}
