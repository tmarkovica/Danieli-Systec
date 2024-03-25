using System.Text;

namespace Task_003;

class Calculator
{
    private const char NO_OPERATION = ' ';

    private double _Result = 0;

    public string Result 
    { 
        get
        {
            if (Operator == NO_OPERATION)
                return _Result.ToString();
            else
                //return Operand + (OperationActive ? Operator : "");
                return Operands[Operands.Count - 1] + (OperationActive ? Operator : "");
        }
        private set
        {
            if (Operator == NO_OPERATION)
                _Result = Double.Parse(value);
        }
    }

    public string Operand { get; set; } = "0";

    public List<string> Operands { get; private set; } = new() { "0" }; // new
    public List<char> Operators { get; private set; } = new(); // new

    private char Operator = NO_OPERATION;
    private bool OperationActive = false;

    private void ResetOperator()
    {
        //Operator = NO_OPERATION;
        //OperationActive = false;

        Operators = new() { NO_OPERATION };
        OperationActive = false;
    }

    private void ResetOperand()
    {
        //Operand = "0";

        Operands = new() { "0" };
    }

    public void Reset()
    {
        _Result = 0;
        ResetOperand();        
        ResetOperator();
    }

    public void CalculateResult()
    {
        //if (Operator == '+')
        //{
        //    _Result += Double.Parse(Operand);
        //}
        //else if (Operator == '-')
        //{
        //    _Result -= Double.Parse(Operand);
        //}
        //else if (Operator == '*')
        //{
        //    _Result *= Double.Parse(Operand);
        //}
        //else if (Operator == '/')
        //{
        //    _Result /= Double.Parse(Operand);
        //}
        //ResetOperator();
        //Operand = Result;

        if (Operator == '+')
        {
            _Result += Double.Parse(Operands.Last());
        }
        else if (Operator == '-')
        {
            _Result -= Double.Parse(Operands.Last());
        }
        else if (Operator == '*')
        {
            _Result *= Double.Parse(Operands.Last());
        }
        else if (Operator == '/')
        {
            _Result /= Double.Parse(Operands.Last());
        }
        ResetOperator();
        Operands[Operands.Count - 1] = Result;

        Operands[Operands.Count - 1] = Result;
    }

    public void NumberInput(string number)
    {
        //if (OperationActive)
        //{
        //    ResetOperand();
        //    OperationActive = false;
        //}

        //if (Operand == "0")
        //    Operand = number;
        //else
        //    Operand += number;

        //Result = Operand;

        if (OperationActive)
        {
            //ResetOperand();
            Operands.Add("0");
            OperationActive = false;
        }

        if (Operands.Last() == "0")
            Operands[Operands.Count - 1] = number;
        else
            Operands[Operands.Count - 1] += number;

        Result = Operands.Last();
    }

    public void SetOperation(char operation)
    {
        //if (Operator != NO_OPERATION)
        //    CalculateResult();

        //Operator = operation;
        //OperationActive = true;

  
        Operators.Add(NO_OPERATION);

        if (Operators.Last() != NO_OPERATION)
            CalculateResult();

        Operators[Operators.Count - 1] = operation;
        OperationActive = true;
    }

    public void PutDecimalPoint()
    {
        //if (Operand.Contains(",") == false)
        //    Operand += ",";

        if (Operands.Last().Contains(",") == false)
            Operands[Operands.Count - 1] += ",";
    }

    public string MathStatement()
    {
        StringBuilder sb = new();

        for (int i = 0; i < Operands.Count; i++)
        {
            sb.Append(Operands[i]);

            if (i < Operators.Count)
                sb.Append(Operators[i]);
        }

        return sb.ToString();
    }
}
