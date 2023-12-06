
using System;
using System.Drawing;

namespace Library.Domain.Creatures.Class
{
    public class Enchanter:Player
    {
        public Enchanter()
        {
            MaxHP = 75;
            CurrentHP = MaxHP;
            Attack = 200;
            SecondDeath = true;
        }

        public override void PlayerSkill()
        {
            Console.WriteLine($"Current MP: {CurrentMP}/{MaxMP}");
            if (CurrentMP >= 50)
            {
                Console.WriteLine("Do you want to pay 50 MP to heal to max health?");
                Console.WriteLine("\t1- Yes\n\t2- No");
                int spellType = 0;

                do
                {
                    if (int.TryParse(Console.ReadLine(), out spellType) && spellType > 0 && spellType < 3)
                        break;
                    Console.WriteLine("Enter a correct number");
                } while (true);

                if (spellType == 1)
                {
                    CurrentMP -= 50;
                    CurrentHP = MaxHP;
                    Stunned = true;
                }
            }

        }

        public override void PlayerDmg(Enemy enemy)
        {
            if (CurrentMP >= 20)
            {
                enemy.TakeDmg(Attack);
                CurrentMP -= 20;
            }
            else
                CurrentMP = MaxMP;

        }
    }
}
