using System.Collections.Generic;

namespace Task_002;

internal class HighestStacedBoxHeapCombination : ICombinationFinder
{
    public void MoveBoxFromPositionToPosition(List<Box> boxes,int from, int to)
    {
        //Box movingBox = boxes[from];
        //boxes.RemoveAt(from);
        //boxes.Insert(to, movingBox);

        Box movingBox = new Box(boxes[from]);
        boxes.RemoveAt(from);
        boxes.Insert(to, movingBox);
    }

    private List<Box> FindNext(List<Box> boxes, int currentBoxIndex)
    {
        if (currentBoxIndex + 1 >= boxes.Count) return boxes;
        
        Console.WriteLine($"> {boxes[currentBoxIndex]}");

        for (int i = currentBoxIndex + 1; i < boxes.Count; i++)
        {
            Console.Write($">>: {boxes[i]}");

            if (boxes[currentBoxIndex].CanPassedBoxBePlacedOnTop(boxes[i]))
            {
                Console.Write(" YES\n");

                Console.WriteLine($"==> moving from ({i})  to ({currentBoxIndex + 1})");
                Console.WriteLine($"\t{boxes[i]} {boxes[currentBoxIndex + 1]}");
                MoveBoxFromPositionToPosition(boxes, i, currentBoxIndex + 1);
                return FindNext(boxes, i);
            }
            else
            {
                Console.Write(" NO\n");

                for (int j = currentBoxIndex - 1; j >= 0; j--)
                {
                    if (boxes[j].CanPassedBoxBePlacedOnTop(boxes[i]))
                    {
                        Console.WriteLine($"==> moving from ({i})  to ({j + 1})");
                        Console.WriteLine($"\t{boxes[i]} --> {boxes[j + 1]}");
                        MoveBoxFromPositionToPosition(boxes, i, j+1);
                        return FindNext(boxes, currentBoxIndex + 1);
                        //return FindNext(boxes, j + 1);
                    }
                }
                boxes.RemoveAt(i);
                i--;
            }
        }
        return boxes;
    }

    private List<Box> NewCombinationStartingWithBox(List<Box> allBoxes, int startingBoxIndex)
    {
        Box startingBox = allBoxes[startingBoxIndex];
        allBoxes.RemoveAt(startingBoxIndex);
        allBoxes.Insert(0, startingBox);

        int heightCount = allBoxes[0].Height;

        var res = FindNext(allBoxes, 0);

        int height = 0;
        for (int i = 0; i < res.Count; i++)
        {
            Console.WriteLine($"{i}: {res[i]}");
            height += res[i].Height;
        }
        Console.WriteLine($"HEIGHT: {height}");

        return res;
    }

    private int TotalBoxesHeight(List<Box> boxes)
    {
        int sum = 0;
        foreach (Box box in boxes) 
        {
            sum += box.Height;
        }
        return sum;
    }

    private int MaxHeightIndex(List<int> heights)
    {
        int maxHeightIndex = 0;
        int maxHeight = heights[0];

        for (int i = 1; i < heights.Count; i++ )
        {
            if (heights[i] > maxHeight)
            {
                maxHeight = heights[i];
                maxHeightIndex = i;
            }
        }
        return maxHeightIndex;
    }

    public void FindCombination(List<Box> allBoxes)
    {
        //List<List<Box>> combinations = new();

        //List<int> heights = new(allBoxes.Count);

        //for (int i = 0; i < allBoxes.Count; i++)
        //{
        //    combinations.Add(NewCombinationStartingWithBox(new List<Box>(allBoxes), i));

        //    heights.Add(TotalBoxesHeight(combinations[i]));
        //    Console.WriteLine("-----------");
        //}

        //int indexOfMaxHeightCombination = MaxHeightIndex(heights);

        //Console.WriteLine($"MaxHeight = {heights[indexOfMaxHeightCombination]}");

        //for (int i = 0; i < combinations[indexOfMaxHeightCombination].Count; i++)
        //    Console.WriteLine($"{i}: {combinations[indexOfMaxHeightCombination][i]}");


        findit(allBoxes);
    }

    private void findit(List<Box> boxes)
    {
        var matrix = PlacementMatrix(boxes);

        List<int> numberOfPossibleBoxesOnTop = new(boxes.Count);

        int counter;
        for (int i = 0; i < boxes.Count; i++)
        {
            counter = 0;

            for (int j = 0; j < boxes.Count; j++)
            {
                if (matrix[j, i] == true)
                    counter++;
            }

            numberOfPossibleBoxesOnTop[i] = counter;
        }

        int indexOfMaxValue, maxValue = numberOfPossibleBoxesOnTop[0];

        for (int i = 1; i < boxes.Count; i++)
        {
            if (numberOfPossibleBoxesOnTop[i] > maxValue)
            {
                maxValue = numberOfPossibleBoxesOnTop[i];
                indexOfMaxValue = i;
            }
        }
    }

    private bool[,] PlacementMatrix(List<Box> boxes)
    {
        bool[,] matrix = new bool[boxes.Count, boxes.Count];

        for (int i = 0; i < boxes.Count; i++)
        {
            for (int j = 0; j < boxes.Count; j++)
            {
                if (i == j)
                    matrix[i, i] = false;
                else
                    matrix[j, i] = boxes[i].CanPassedBoxBePlacedOnTop(boxes[j]);
            }
        }

        return matrix;
    }
}
