class Human
{
    // properties for human
    public string Name;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    public int Health;

    // human constructor that takes Name value, and sets remaining fields to default
    public Human(string name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        Health = 100;
    }

    // 
    public Human(string name, int strength, int intelligence, int dexterity, int health)
    {
        Name = name;
        Strength = strength;
        Intelligence = intelligence;
        Dexterity = dexterity;
        Health = health;
    }

    public int Attack(Human target)
    {
        int Damage = Strength * 5;
        target.Health -= Damage;
        return target.Health;
    }
}