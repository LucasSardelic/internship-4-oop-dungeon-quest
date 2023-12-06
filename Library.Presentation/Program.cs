using Library.Domain;
using Library.Domain.Creatures;
using Library.Domain.Creatures.Class;
using Library.Domain.Creatures.EnemyType;
using System;

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

var enemy = new Brute();

player.SetMaxHP(player.Size);
if (enemy.Encounter(player, enemy))
{
    Console.WriteLine("You won!");
}
else if(player.SecondDeath==true)
{
    player.SecondDeath = false;
    player.CurrentHP = player.MaxHP;
    player.CurrentMP = player.MaxMP;
    Console.WriteLine("A powerful magic spell is still binding you to this realm... For now!");
    Console.WriteLine("You have used your sigle extra life.");
}
else
{
    Console.WriteLine("You died!");
}
