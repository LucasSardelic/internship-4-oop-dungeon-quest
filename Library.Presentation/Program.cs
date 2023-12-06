using Library.Domain;
using Library.Domain.Creatures;
using Library.Domain.Creatures.Class;
using Library.Domain.Creatures.EnemyType;
using System;

var DungeonFloors = new Dictionary<int, (string, int, int)>()
{
    {1, ("goblin", 50, 50)}
};

for (int i = 2; i < 11; i++)
{
    var randomNum = new Random();
    int randomState = randomNum.Next(100);

    if (i < 6)
    {
        if(randomState>65)
            DungeonFloors[i] = ("brute", 200, 200);
        else
            DungeonFloors[i] = ("goblin", 50, 50);
    }
    else
    {
        if(randomState>80)
            DungeonFloors[i] = ("witch", 100, 100);
        else if(randomState>50)
            DungeonFloors[i] = ("brute", 200, 200);
        else
            DungeonFloors[i] = ("goblin", 50, 50);
    }
}

Console.WriteLine("-- Choose your class --\n");
Console.WriteLine("1. Gladiator:\n\t-high health but low dammage\n\t-can trade health to enter rage mode and double his power temporarily");
Console.WriteLine("2. Enchanter:\n\t-low health but high dammage spells\n\t-needs to manage MP(mana) gauge to cast his spells" +
    "\n\t-can heal himself\n\t-can cheat death ONCE per run");
Console.WriteLine("3. Marksman\n\t-balanced stats\n\t-has a chance to inflict a critical hit\n\t-has a chance to stun the enemy");
Console.WriteLine("0. Exit the game");
int ClassChoice = 0;

do
{
    if (int.TryParse(Console.ReadLine(), out ClassChoice) && ClassChoice >= 0 && ClassChoice < 4)
        break;
    Console.WriteLine("Enter a correct number");
} while (true);

var player = new Player();

if (ClassChoice == 1)
    player = new Gladiator();
else if (ClassChoice == 2)
    player = new Enchanter();
else if (ClassChoice == 3)
    player = new Marksman();
else
    return;

var enemy = new Enemy();

player.SetMaxHP(player.Size);
int floor = 0;

do
{
    floor++;

    if (DungeonFloors[floor].Item1 == "goblin")
        enemy = new Goblin();
    else if (DungeonFloors[floor].Item1 == "brute")
        enemy = new Brute();
    else
        enemy = new Witch();

    enemy.MaxHP = DungeonFloors[floor].Item2;
    enemy.CurrentHP = DungeonFloors[floor].Item3;

    if (enemy.Encounter(player, enemy, floor))
    {
        Console.WriteLine("You killed the beast, prepare yourself for you venture ever deeper...");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("You died!");
        Console.WriteLine("Try again?\n\t1- Yes\n\t2- No");
        int answer = 0;

        do
        {
            if (int.TryParse(Console.ReadLine(), out answer) && answer > 0 && answer < 3)
                break;
            Console.WriteLine("Enter a correct number");
        } while (true);

        if (answer == 1)
            floor = 0;
        else
            break;
    }
} while (floor <= 10);

if (floor >= 10)
{
    Console.Clear();
    Console.WriteLine("Congratulations, you traversed grave woes and perils to get to this point." +
        "The evil that once roamed in this dungeon is no more, and with that knowledge under your belt," +
        "you realize you found yourself a spacious and well protected home to slowly age in peace." +
        "As you sit on a luxurious golden throne, symbol of your hard labor, the deep silence makes you" +
        "realize that being the only one left alive feels kinda lonely...\n\nAnd it is with that new tought" +
        "that you charge forward towards your next adventure.");
}



