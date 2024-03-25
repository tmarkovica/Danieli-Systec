namespace Task_002;

public class TaskSolution
{
    private readonly BoxStack _stack;

    public TaskSolution()
    {
        _stack = new BoxStack(10);
        Console.WriteLine("CREATED BOXES: ");
        Console.WriteLine(_stack);
    }

    public void FindSolution(CombinationFinder strategy)
    {
        Console.WriteLine($"===============================================================");
        Console.WriteLine($"\t\t\tTASK {strategy.TaskLabel()}");
        Console.WriteLine($"===============================================================");

        strategy.FindCombination(new BoxStack(_stack));
    }
}
