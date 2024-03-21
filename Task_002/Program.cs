using Task_002;

//List<Box> boxes = new();

//for (int i = 0; i < 10; i++)
//    boxes.Add(new Box());

List<Box> boxes = new()
{
    new Box(9,3,9),
    new Box(1,7,9),
    new Box(5,3,6),
    new Box(8,2,9),
    new Box(6,7,4),
    new Box(1,2,7),
    new Box(9,1,5),
    new Box(8,9,8),
    new Box(4,2,9),
    new Box(5,7,7),
};


Console.WriteLine("CREATED BOXES: ", boxes.Count);
Console.WriteLine("-------------------------------------------------------");

for (int i = 0; i < boxes.Count; i++)
    Console.WriteLine($"{i}: {boxes[i]}");

Console.WriteLine("-------------------------------------------------------");


TaskSolution taskSolution = new TaskSolution(boxes);

ICombinationFinder task1 = new HighestStacedBoxHeapCombination();
taskSolution.FindSolution(task1);

//ICombinationFinder task2 = new HighestStacedBoxHeapCombination();
//taskSolution.FindSolution(task2);

Console.WriteLine("-------------------------------------------------------");
Console.WriteLine("ORIGINAL!");

for (int i = 0; i < boxes.Count; i++)
    Console.WriteLine($"{i}: {boxes[i]}");