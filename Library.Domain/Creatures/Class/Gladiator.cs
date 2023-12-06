
namespace Library.Domain.Creatures.Class
{
    public class Gladiator:Player
    {
        public bool Rage { get; set; }
        public Gladiator()
        {
            Size = "large";
            Attack = "weak";
        }

        public override void PlayerSkill()
        {
            Console.WriteLine("Do you want to pay 5% HP to double your dmg output this turn?");
            Console.WriteLine("\t1- Yes\n\t2- No");
            int attackType = 0;

            do
            {
                if (int.TryParse(Console.ReadLine(), out attackType) && attackType > 0 && attackType < 3)
                    break;
                Console.WriteLine("Enter a correct number");
            } while (true);

            if(attackType==1)
            {
                CurrentHP -= MaxHP * 5 / 100;
                Rage = true;
            }
            else
                Rage = false;
        }

        public override void PlayerDmg(Enemy enemy)
        {
            if (Rage == true)
            {
                Console.WriteLine("The enraged blow is crushing!");
                enemy.TakeDmg(Attack);
                enemy.TakeDmg(Attack);
            }
            else
            {
                enemy.TakeDmg(Attack);
            }

        }
    }
}
