// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// first instance of an animal
Animal Dog = new Animal("Dog", 60.3, "Ominvore", true);
Animal Cat = new Animal("Cat", 15.5, "Ominvore", true);
Animal Bear = new Animal("Bear", 160.3, "Ominvore");
Animal Coyote = new Animal("Coyote", 56.2);

Console.WriteLine(Dog.Diet);
Console.WriteLine(Bear.isFriendly);
Console.WriteLine(Dog.isFriendly);
Console.WriteLine(Coyote.Diet);

Coyote.makeNoise("Howl");

Mammal Lion = new Mammal("Lion", 120, "Omnivore", false);

Console.WriteLine(Lion.Weight);