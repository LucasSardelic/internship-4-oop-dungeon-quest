using Library.Domain.Creatures.EnemyType;

namespace Library.Domain.Creatures
{
    public class Enemy:Creature
    {
        public int EnemyAttack {  get; set; }
        public Enemy()
        {
            
        }
        public void EnemyAttackGenerator()
        {
            var randomNum = new Random();
            //1-Direct, 2-Side, 3-Counter
            EnemyAttack= randomNum.Next(3) + 1;
        }

        public bool Encounter(Player player, Enemy enemy)
        {
            bool outcome;
            enemy.SetMaxHP(Size);

            do
            {
                Console.Clear();
                Console.WriteLine($"You are facing a {enemy.Name}!");
                Console.WriteLine($"Current HP: {player.CurrentHP}/{player.MaxHP}");
                Console.WriteLine($"Enemy HP: {enemy.CurrentHP}/{enemy.MaxHP}");
                Console.WriteLine("What is your next move?\n\t1-Direct attack\n\t2-Side attack\n\t3-Counter");
                int attackType = 0;

                do
                {
                    if (int.TryParse(Console.ReadLine(), out attackType) && attackType > 0 && attackType < 4)
                        break;
                    Console.WriteLine("Enter a correct number");
                } while (true);

                enemy.EnemyAttackGenerator();

                if (attackType == enemy.EnemyAttack)
                {
                    Console.WriteLine($"The enemy chose {enemy.EnemyAttack}, draw!");
                }
                else if ((attackType == enemy.EnemyAttack + 1) || (enemy.EnemyAttack == 3 && attackType == 1))
                {
                    Console.WriteLine($"The enemy chose {enemy.EnemyAttack}, you get hit!");
                    EnemyDmg(player);
                }
                else
                {
                    Console.WriteLine($"The enemy chose {enemy.EnemyAttack}, you hit him!");
                    enemy.TakeDmg(player.Attack);
                }

                if (!enemy.CheckIsAlive())
                {
                    outcome = true;
                    break;
                }
                else if (!player.CheckIsAlive())
                {
                    outcome = false;
                    break;
                }

                Console.ReadKey();
            } while (true);
            return outcome;
        }

        public virtual void EnemyDmg(Player player)
        {
            player.TakeDmg("strong");
        }
    }
}
