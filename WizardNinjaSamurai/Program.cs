Human FreeGuy = new Human("Guy");

Ninja Ichigo = new Ninja("Ichigo");

Samurai Jaraiya = new Samurai("Jaraiya");

Wizard Strange = new Wizard("Dr. Strange");


Console.WriteLine("================== ICHIGO VS JARAIYA =================");
Ichigo.Steal(Jaraiya);
Ichigo.Attack(Jaraiya);
Jaraiya.Meditate();



Console.WriteLine("================== Dr. Strange VS JARAIYA =================");
Jaraiya.Attack(Strange);
Strange.Heal(Strange);
Strange.Attack(Jaraiya);
Jaraiya.Meditate();



