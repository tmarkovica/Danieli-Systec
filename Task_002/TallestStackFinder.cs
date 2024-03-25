namespace Task_002;

public class TallestStackFinder : CombinationFinder
{
    public override string TaskLabel() => "a";

    public override void FindCombination(BoxStack stack)
    {
        BoxStack tallestStack = FindTallestStackCombinationOfBoxes(stack);

        Console.WriteLine($"STACK HEIGHT = {tallestStack.StackHeight()}");
        Console.Write(tallestStack);
    }

    private static List<int> StacksHeights(List<BoxStack> stacks)
    {
        List<int> heights = new();
        foreach (BoxStack stack in stacks)
            heights.Add(stack.StackHeight());
        return heights;
    }

    private static int FindIndexOfTheHighestStack(List<BoxStack> stacks)
    {
        List<int> heights = StacksHeights(stacks);
        return CollectionsUtils.MaxValueIndex(heights.ToArray());
    }

    private static BoxStack UseBoxAtGivenPositionAsStackBottom_StackPossibleRemainingBoxesOnTop(
        BoxStack orderedStack, int bottomBoxIndex)
    {
        BoxStack newStack = new();

        Box bottomBox = orderedStack.RemoveAndReturn(bottomBoxIndex);
        newStack.Push(bottomBox);

        for (int i = orderedStack.Count() - 1; i >= 0; i--)
            if (newStack.StackToBottom(orderedStack[i]))
                orderedStack.Remove(i);

        for (int i = orderedStack.Count() - 1; i >= 0; i--)
            if (newStack.StackOnTop(orderedStack[i]))
                orderedStack.Remove(i);


        return newStack;
    }

    private static BoxStack FindTallestStackCombinationOfBoxes(BoxStack stack)
    {
        BoxStack orderedStack = OrderStackBoxes(stack);

        List<BoxStack> stacksOfBoxes = new();

        for (int i = 0; i < orderedStack.Count(); i++)
        {
            stacksOfBoxes.Add(
                UseBoxAtGivenPositionAsStackBottom_StackPossibleRemainingBoxesOnTop(new BoxStack(orderedStack), i)
                );
        }

        int maxHeightStackIndex = FindIndexOfTheHighestStack(stacksOfBoxes);

        return stacksOfBoxes[maxHeightStackIndex];
    }
}
