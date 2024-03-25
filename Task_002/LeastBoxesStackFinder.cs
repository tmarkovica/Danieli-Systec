namespace Task_002;

public class LeastBoxesStackFinder : CombinationFinder
{
    public override string TaskLabel() => "b";

    private static bool PlaceBox_ToStackInWhichThisBoxCanBeOnBottom(List<BoxStack> stacksOfBoxes, Box box)
    {
        for (int i = 0; i < stacksOfBoxes.Count; i++)
        {
            if (box.CanPassedBoxBePlacedOnTop(stacksOfBoxes[i].BottomBox()))
            {
                stacksOfBoxes[i].Insert(0, box);                
                return true;
            }
        }
        return false;
    }

    private static List<BoxStack> FindLeastNumberOfStacksForCombinationOfBoxes(BoxStack stack)
    {
        BoxStack orderedStack = OrderStackBoxes(stack);

        List<BoxStack> stacksOfBoxes = new();

        while (orderedStack.Count() > 0)
        {
            Box boxTakenFromTop = orderedStack.Pop();
            if (PlaceBox_ToStackInWhichThisBoxCanBeOnBottom(stacksOfBoxes, boxTakenFromTop) == false)
            {
                BoxStack newStack = new();
                newStack.StackOnTop(boxTakenFromTop);
                stacksOfBoxes.Add(newStack);
            }
        }
        return stacksOfBoxes;
    }

    public override void FindCombination(BoxStack stack)
    {
        List<BoxStack> resultStacks = FindLeastNumberOfStacksForCombinationOfBoxes(stack);
        
        Console.WriteLine($"NUMBER OF STACKS = {resultStacks.Count}");

        for (int i = 0; i < resultStacks.Count; i++)
        {
            Console.WriteLine($"--------------------------------------------- STACK {i}");
            Console.Write(resultStacks[i]);
        }
    }
}
