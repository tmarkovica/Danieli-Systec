using Task_002;

TaskSolution taskSolution = new();

CombinationFinder task1 = new TallestStackFinder();
taskSolution.FindSolution(task1);

Console.WriteLine();
Console.WriteLine();

CombinationFinder task2 = new LeastBoxesStackFinder();
taskSolution.FindSolution(task2);