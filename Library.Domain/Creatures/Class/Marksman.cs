
using System.Numerics;

namespace Library.Domain.Creatures.Class
{
    public class Marksman:Player
    {
        public Marksman()
        {
            Size = "medium";
            Attack = "medium";
        }

        public override void PlayerDmg(Enemy enemy)
        {
            var randomNum = new Random();
            int critChance = randomNum.Next(100);
            int stunChance = randomNum.Next(100);

            if (critChance > 90)
            {
                Console.WriteLine("You aim at a vital spot and score a critical hit!");
                enemy.TakeDmg(Attack);
                enemy.TakeDmg(Attack);
            }
            else
            {
                enemy.TakeDmg(Attack);
            }

            if(stunChance > 90)
            {
                Console.WriteLine("You stunned the enemy!");
                enemy.Stunned=true;
            }

        }
    }
}
