
using System.Numerics;

namespace Library.Domain.Creatures.Class
{
    public class Marksman:Player
    {
        public Marksman()
        {
            MaxHP = 150;
            CurrentHP = MaxHP;
            Attack = 100;
        }

        public override void PlayerDmg(Enemy enemy)
        {
            var randomNum = new Random();
            int critChance = randomNum.Next(100);
            int stunChance = randomNum.Next(100);

            if (critChance > Crit)
            {
                Console.WriteLine("You aim at a vital spot and score a critical hit!");
                enemy.TakeDmg(Attack);
                enemy.TakeDmg(Attack);
            }
            else
            {
                enemy.TakeDmg(Attack);
            }

            if(stunChance > Stun)
            {
                Console.WriteLine("You stunned the enemy!");
                enemy.Stunned=true;
            }

        }
    }
}
