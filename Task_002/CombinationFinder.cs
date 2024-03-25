namespace Task_002;

public abstract class CombinationFinder
{
    public abstract void FindCombination(BoxStack stack);
    public abstract string TaskLabel();

    private static bool PlaceBoxHigherInStack_OnTheFirstHigherBoxItCanBePlaced(BoxStack stack, Box box)
    {
        for (int i = 0; i < stack.Count(); i++)
        {
            if (stack[i].CanPassedBoxBePlacedOnTop(box))
            {
                stack.Insert(i + 1, box);
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// It will return all the boxes from the original stack but in 'order' and not
    /// all of them passing the stacking conditions. 
    /// This will only roughly order boxes by it's sizes, from where other kinds of sorting boxes
    /// can be continued and more easily done.
    /// <br/>
    /// Until original stack is empty, always proceeds to move bottom box of the original stack
    /// to the first box higher in that stack on which moving box can be placed (stacking condition).
    /// This makes sure that smallest boxes go to top of the stack, and bigger boxes got to bottom of stack.
    /// When box can't be moved anywhere higher from it's current position in a stack, then
    /// that box is moved to another 'ordered' stack.
    /// </summary>
    /// <param name="originalStack"></param>
    /// <returns>Boxes roughly ordered by their sizes (length and height).</returns>
    public static BoxStack OrderStackBoxes(BoxStack originalStack)
    {
        BoxStack orderedStack = new();

        while (originalStack.Count() > 0)
        {
            Box boxFromBottom = originalStack.PopBottom();
            if (PlaceBoxHigherInStack_OnTheFirstHigherBoxItCanBePlaced(originalStack, boxFromBottom) == false)
                orderedStack.Push(boxFromBottom);
        }
        return orderedStack;
    }
}