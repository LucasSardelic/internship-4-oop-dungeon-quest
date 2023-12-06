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

        public bool Encounter(Player player, Enemy enemy, int floor)
        {
            bool outcome;
            enemy.SetMaxHP(Size);

            do
            {
                Console.Clear();
                Console.WriteLine($"-- Floor {floor} --");
                Console.WriteLine($"You are facing a {enemy.Name}!");
                Console.WriteLine($"Enemy HP: {enemy.CurrentHP}/{enemy.MaxHP}");
                Console.WriteLine($"Current HP: {player.CurrentHP}/{player.MaxHP}");
                int attackType = player.PlayerAttack();

                enemy.EnemyAttackGenerator();

                if (enemy.Stunned==true)
                {
                    Console.WriteLine($"The enemy is stunned, you hit him!");
                    enemy.Stunned = false;
                    player.PlayerDmg(enemy);
                }
                else if (attackType == 0)
                {
                    Console.WriteLine($"You healed to full HP, but the enemy still hit you!");
                    player.Stunned= false;
                    EnemyDmg(player);
                }
                else if (attackType == enemy.EnemyAttack)
                {
                    Console.WriteLine($"The enemy chose {enemy.EnemyAttack}, draw!");
                }
                else if ((attackType == enemy.EnemyAttack + 1) || (enemy.EnemyAttack == 3 && attackType == 1))
                {
                    Console.WriteLine($"The enemy chose {enemy.EnemyAttack}, you get hit!");
                    EnemyDmg(player);
                }
                else if (CurrentMP<20)
                {
                    Console.WriteLine($"You recharge your mana!");
                    player.PlayerDmg(enemy);
                }
                else
                {
                    Console.WriteLine($"The enemy chose {enemy.EnemyAttack}, you hit him!");
                    player.PlayerDmg(enemy);
                }

                if (!enemy.CheckIsAlive())
                {
                    outcome = true;
                    break;
                }
                else if (!player.CheckIsAlive() && player.SecondDeath==true)
                {
                    player.SecondDeath = false;
                    player.CurrentHP = player.MaxHP;
                    player.CurrentMP = player.MaxMP;
                    Console.WriteLine("A powerful magic spell is still binding you to this realm... For now!");
                    Console.WriteLine("You have used your sigle extra life.");
                }
                else if(!player.CheckIsAlive())
                {
                    outcome = false;
                    break;
                }

                Console.ReadKey();
            } while (true);
            return outcome;
        }

        public virtual void EnemyDmg(Player player){}
    }
}
