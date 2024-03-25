using System.Collections;
using System.Text;

namespace Task_002;

public class BoxStack : IEnumerable<Box>
{
    private readonly List<Box> _stack;

    private static List<Box> CreateRandomBoxes(int numberOfBoxes)
    {
        List<Box> boxes = new();
        for (int i = 0; i < numberOfBoxes; i++)
            boxes.Add(new Box());
        return boxes;

        //return new List<Box>()
        //{
        //    new(9,3,9),
        //    new(1,7,9),
        //    new(5,3,6),
        //    new(8,2,9),
        //    new(6,7,4),
        //    new(1,2,7),
        //    new(9,1,5),
        //    new(8,9,8),
        //    new(4,2,9),
        //    new(5,7,7),

        //    //new Box(9,3,1),
        //    //new Box(1,7,9),
        //    //new Box(5,3,1),
        //    //new Box(8,2,1),
        //    //new Box(6,7,1),
        //    //new Box(1,2,9),
        //    //new Box(9,1,1),
        //    //new Box(8,9,1),
        //    //new Box(4,2,1),
        //    //new Box(5,7,1),
        //};
    }

    public BoxStack()
    {
        _stack = new();
    }

    public BoxStack(int numberOfBoxes)
    {
        _stack = CreateRandomBoxes(numberOfBoxes);
    }

    public BoxStack(BoxStack stack)
    {
        _stack = stack.ToList();
    }

    public IEnumerator GetEnumerator()
    {
        return GetEnumerator();
    }

    IEnumerator<Box> IEnumerable<Box>.GetEnumerator()
    {
        return (IEnumerator<Box>)_stack.AsEnumerable();
    }

    public int StackHeight()
    {
        int sum = 0;
        foreach (Box box in _stack)
            sum += box.Height;
        return sum;
    }

    public void Push(Box box)
    {
        _stack.Add(box);
    }

    public Box Pop()
    {
        Box box = _stack[_stack.Count - 1];
        _stack.RemoveAt(_stack.Count - 1);
        return box;
    }

    public Box PopBottom()
    {
        Box box = _stack[0];
        _stack.RemoveAt(0);
        return box;
    }

    /// <summary>
    /// Method requires box to pass stacking condition to be added to stack.
    /// </summary>
    /// <param name="box"></param>
    /// <returns></returns>
    public bool StackToBottom(Box box)
    {
        if (_stack.Count == 0)
        {
            Push(box);
            return true;
        }

        if (box.CanPassedBoxBePlacedOnTop(_stack[0]))
        {
            _stack.Insert(0, box);
            return true;
        }
        else return false;
    }

    /// <summary>
    /// Method requires box to pass stacking condition to be added to stack.
    /// </summary>
    /// <param name="box"></param>
    /// <returns></returns>
    public bool StackOnTop(Box box)
    {
        if (_stack.Count == 0)
        {
            Push(box);
            return true;
        }

        if (_stack[_stack.Count - 1].CanPassedBoxBePlacedOnTop(box))
        {
            Push(box);
            return true;
        }
        else return false;
    }

    public void Remove(int index)
    {
        //Console.WriteLine($"X Removing {_stack[index]} \tfrom position {index}");
        _stack.RemoveAt(index);
    }

    public Box RemoveAndReturn(int index)
    {
        Box temp = _stack[index];
        _stack.RemoveAt(index);
        return temp;
    }

    public void Move(int from, int to)
    {
        //Console.WriteLine($"<> Moving {_stack[from]} \tfrom position {from} to position {to}");
        Box movingBox = new(_stack[from]);
        _stack.RemoveAt(from);
        _stack.Insert(to, movingBox);
    }

    public void Insert(int index, Box box) => _stack.Insert(index, box);

    public Box TopBox() =>_stack.Last();

    public Box BottomBox() => _stack[0];

    public override string ToString()
    {
        if (_stack.Count == 0) return "STACK IS EMPTY";
        StringBuilder sb = new();
        foreach (Box b in _stack)
            sb.AppendLine(b.ToString());
        return sb.ToString();
    }

    public Box this[int key]
    {
        get => _stack[key];
        set => _stack[key] = value;
    }

    public int Count() {  return _stack.Count; }

    public List<Box> ToList() => new(_stack);
}
