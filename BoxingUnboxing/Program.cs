List<object> empty = new List<object>();

empty.Add(7);
empty.Add(28);
empty.Add(-1);
empty.Add(true);
empty.Add("chair");

int open = 0;

foreach (var x in empty)
{
    System.Console.WriteLine(x);
    if (x is int)
    {
        open += (int)x;
    }
}

    System.Console.WriteLine(open);