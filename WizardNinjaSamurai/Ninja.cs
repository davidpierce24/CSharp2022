class Ninja : Human
{
    public Ninja(string name) : base(name)
    {
        Dexterity = 175;
    }

    public override int Attack(Human target)
    {
        int Damage = Dexterity * 5;
        target.Health -= Damage;
        Random rand = new Random();
        int Chance = rand.Next(0,5);
        if(Chance == 2){
            target.Health -= 10;
            Damage += 10;
        }
        Console.WriteLine($"{Name} backhanded {target.Name} for {Damage} damage");
        Console.WriteLine($"{target.Name}'s health is {target.Health}");
        return target.Health;
    }

    public int Steal(Human target)
    {
        target.Health -= 5;
        Health += 5;
        Console.WriteLine($"{Name} swiped 5 health from {target.Name}");
        Console.WriteLine($"{target.Name}'s health is {target.Health}");
        Console.WriteLine($"{Name}'s health is {Health}");
        return target.Health;
    }
}