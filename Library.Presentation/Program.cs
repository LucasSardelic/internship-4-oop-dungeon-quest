using Library.Domain;
using Library.Domain.Creatures;
using Library.Domain.Creatures.EnemyType;
using System;

var enemy = new Brute();
var player = new Player();
player.SetMaxHP(player.Size);
if (enemy.Encounter(player, enemy))
{
    Console.WriteLine("You won!");
}
else
{
    Console.WriteLine("You died!");
}
