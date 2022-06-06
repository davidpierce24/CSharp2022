// print all values 1-255
// for (int i = 1; i <= 255; i++)
// {
//     Console.WriteLine (i);
// }

// print all values 1-100 divisble by 3 or 5 but not both
// for (int i = 1; i <= 100; i++)
// {
//     if(i%3 == 0 && i%5 == 0){
//         continue;
//     }
//     if(i%3 == 0 || i%5 == 0){
//         Console.WriteLine (i);
//     }
// }

// 3
// for (int i = 1; i <= 100; i++)
// {
//     if(i%3 == 0 && i%5 == 0){
//         Console.WriteLine ("FizzBuzz");
//     }
//     if(i%3 == 0){
//         Console.WriteLine ("Fizz");
//     }
//     if(i%5 == 0){
//         Console.WriteLine ("Buzz");
//     }
// }

// Optional
int i = 1;
while (i <= 100)
{
    if(i%3 == 0 && i%5 == 0){
        Console.WriteLine ("FizzBuzz");
    }
    if(i%3 == 0){
        Console.WriteLine ("Fizz");
    }
    if(i%5 == 0){
        Console.WriteLine ("Buzz");
    }
    i++;
}