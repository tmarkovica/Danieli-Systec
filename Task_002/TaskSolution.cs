namespace Task_002;

internal class TaskSolution
{
    private readonly List<Box> _allBoxes;

    public TaskSolution(List<Box> allBoxes)
    {
        _allBoxes = allBoxes;
    }

    public void FindSolution(ICombinationFinder strategy)
    {
        strategy.FindCombination(new List<Box>(_allBoxes));
    }
}
