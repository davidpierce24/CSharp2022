class Mammal : Animal
{
    public bool hasFur = true;

    public Mammal(string species, double weight, string diet, bool isFriendly) : base(species, weight, diet, isFriendly){}
}