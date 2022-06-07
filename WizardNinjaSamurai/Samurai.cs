class Samurai : Human
{
    public Samurai(string name) : base(name)
    {
        Health = 200;
    }
    
    public override int Attack(Human target)
    {
        base.Attack(target);
        if(target.Health < 50){
            target.Health = 0;
            Console.WriteLine($"{target.Name} was backhanded and incurred great shame upon his family. {target.Name} performed seppuku and perished in the streets, but restored honor to his family :0");
        }
        return target.Health;
    }

    public int Meditate()
    {
        Health = 200;
        Console.WriteLine($"{Name} aligned his chakra for full health restore");
        Console.WriteLine($"{Name}'s health is {Health}");
        return Health;
    }
}

