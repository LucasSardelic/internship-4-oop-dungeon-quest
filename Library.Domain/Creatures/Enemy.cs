﻿using Library.Domain.Creatures.EnemyType;

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

        public bool Encounter(Player player, Enemy enemy, int floor, Dictionary<int, (string, int, int)> dungeonFloors)
        {
            bool outcome;

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
                    EnemyDmg(player, dungeonFloors, floor);
                }
                else if (attackType == enemy.EnemyAttack)
                {
                    Console.WriteLine($"The enemy chose {enemy.EnemyAttack}, draw!");
                }
                else if ((attackType == enemy.EnemyAttack + 1) || (enemy.EnemyAttack == 3 && attackType == 1))
                {
                    Console.WriteLine($"The enemy chose {enemy.EnemyAttack}, you get hit!");
                    EnemyDmg(player, dungeonFloors, floor);
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
                    player.CurrentXp += enemy.XpValue;
                    Console.WriteLine(player.CurrentXp);
                    Console.ReadKey();
                    player.CurrentHP += player.MaxHP * 25 / 100;
                    if (player.CurrentHP > player.MaxHP)
                    { player.CurrentHP = player.MaxHP; }
                    player.CurrentMP = player.MaxMP;
                    if(player.CurrentXp>100)
                    {
                        player.CurrentXp -= 100;
                        CurrentLvl += 1;
                        player.MaxHP += 15;
                        player.MaxMP += 15;
                        player.CurrentMP += 15;
                        player.CurrentHP += 15;
                        if(player.CurrentHP>player.MaxHP)
                        { player.CurrentHP = player.MaxHP; }
                        player.Attack += 5;
                        player.Crit -= 2;
                        player.Stun -= 2;
                        Console.WriteLine($"You are now level {CurrentLvl}");
                        Console.ReadKey();
                    }
                    outcome = true;

                    if(enemy.Name == "witch")
                    {
                        enemy = new Goblin();

                        if (enemy.Encounter(player, enemy, floor, dungeonFloors))
                        {
                            Console.WriteLine("You killed a witch spawn");
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
                    }
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

        public virtual void EnemyDmg(Player player, Dictionary<int, (string, int, int)> dungeonFloors, int floor) {}
    }
}
