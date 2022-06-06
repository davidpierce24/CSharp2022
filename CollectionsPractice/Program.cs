// Three basic arrays
int [] arr1 = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

string [] arr2 = {"Tim", "Martin", "Nikki", "Sara"};

bool [] arr3 = new bool[10];
for(int i = 0; i < 10; i++)
{
    if(i%2 == 1)
    {
        arr3[i] = false;
    }
    else
    {
        arr3[i] = true;
    }
    System.Console.WriteLine(arr3[i]);
}



// List of flavors
List<string> iceCream = new List<string>();

iceCream.Add("Oreo");
iceCream.Add("Chocolate");
iceCream.Add("Cookie Dough");
iceCream.Add("Vanilla");
iceCream.Add("Oreo Latte");

System.Console.WriteLine(iceCream.Count);

System.Console.WriteLine(iceCream[2]);
iceCream.RemoveAt(2);
System.Console.WriteLine(iceCream[2]);

System.Console.WriteLine(iceCream.Count);



// User info dictionary
Dictionary<string, string> user = new Dictionary<string, string>();

Random rand = new Random();
for(int i = 0; i < arr2.Length; i++)
{
    user.Add(arr2[i], iceCream[rand.Next(0,4)]);
}

foreach (KeyValuePair<string,string> entry in user)
{
    System.Console.WriteLine(entry.Key + " - " + entry.Value);
}
