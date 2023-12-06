using Library.Domain;
using Library.Domain.Creatures;

var player = new Player();
var enemy = new Enemy();
player.SetMaxHP();
enemy.SetMaxHP();

do
{
    Console.Clear();
    Console.WriteLine($"Current HP: {player.CurrentHP}");
    Console.WriteLine($"Enemy HP: {enemy.CurrentHP}");
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
        player.TakeDmg();
    }
    else
    {
        Console.WriteLine($"The enemy chose {enemy.EnemyAttack}, you hit him!");
        enemy.TakeDmg();
    }

    if (!enemy.CheckIsAlive())
    {
        Console.WriteLine("You won!");
        break;
    }
    else if (!player.CheckIsAlive())
    {
        Console.WriteLine("You died!");
        break;
    }

    Console.ReadKey();
} while (true);
