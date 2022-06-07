class Animal
{
    // establish the attributes of the class
    // words used to describe an item
    public string Species;
    public double Weight;
    public string Diet;
    public bool isFriendly;

    // this is our constructor
    public Animal(string species, double weight, string diet)
    {
        Species = species;
        Weight = weight;
        Diet = diet;
        isFriendly = false;
    }

    public Animal(string species, double weight, string diet, bool isFr)
    {
        Species = species;
        Weight = weight;
        Diet = diet;
        isFriendly = isFr;
    }

    // second constructor with only 2 attributes that autofills the last one
    public Animal(string species, double weight)
    {
        Species = species;
        Weight = weight;
        Diet = "Ominvore";
    }
}