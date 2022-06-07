// Random array
static int[] RandomArray()
{
    Random rand  = new Random();
    int sum = 0;
    int[] arr = new int[10];
    for(int i = 0; i < arr.Length; i++){
        arr[i] = rand.Next(5,25);
        sum += arr[i];
    }
    System.Console.WriteLine(arr.Min());
    System.Console.WriteLine(arr.Max());
    System.Console.WriteLine(sum);
    return arr;
}

RandomArray();


// Coin Flip
static string TossCoin()
{
    Console.WriteLine("Tossing a Coin");
    Random rand = new Random();
    int toss = rand.Next(0,2);
    // Console.WriteLine(toss);
    if(toss == 1){
        Console.WriteLine("Heads!");
        return "Heads!";
    } else {
        Console.WriteLine("Tails!");
        return "Tails!";
    }
}

TossCoin();


static double TossMultipleCoins(int num)
{
    Console.WriteLine("Tossing a Coin");
    Random rand = new Random();
    double heads = 0;
    double tails = 0;
    for(int i = 0; i < num; i++){
        int toss = rand.Next(0,2);
        // Console.WriteLine(toss);
        if(toss == 1){
            heads += 1;
        } else {
            tails += 1;
        }
    }
    double ratio = heads/(heads + tails);
    Console.WriteLine(heads);
    Console.WriteLine(tails);
    Console.WriteLine(ratio);
    return (ratio);
}

TossMultipleCoins(7);


// Names
static List<string> Names()
{
    List<string> names = new List<string>{"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
    List<string> tooLong = new List<string>();
    for(int i = 0; i < names.Count; i++){
        if(names[i].Length > 5){
            tooLong.Add(names[i]);
        }
    }
    System.Console.WriteLine(tooLong);
    return tooLong;
}

Names();