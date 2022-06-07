class Wizard : Human
{
    public Wizard(string name) : base(name)
    {
        Intelligence = 25;
        Health = 50;
    }

    public override int Attack(Human target)
    {
        int Damage = Intelligence * 5;
        target.Health -= Damage;
        Health += Damage;
        Console.WriteLine($"{Name} backhanded {target.Name} for {Damage} damage");
        Console.WriteLine($"{target.Name}'s health is {target.Health}");
        Console.WriteLine($"{Name}'s health is {Health}");
        return target.Health;
    }

    public int Heal(Human target)
    {
        int Healing = Intelligence * 10;
        target.Health += Healing;
        Console.WriteLine($"{Name} healed {target.Name} for {Healing} health");
        Console.WriteLine($"{target.Name}'s health is {target.Health}");
        return target.Health;
    }
}