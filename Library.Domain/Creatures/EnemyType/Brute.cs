
namespace Library.Domain.Creatures.EnemyType
{
    public class Brute:Enemy
    {
        public Brute()
        {
            Size = "large";
            Attack = "medium";
            Name = "brute";
        }
        public override void EnemyDmg(Player player)
        {
            var randomNum = new Random();
            int randomState = randomNum.Next(10);
            if (randomState == 9)
            {
                Console.WriteLine("The brute deals a massive blow! you lose 25% of your max HP");
                player.TakeDmg("brute");
            }
            else
            {
                player.TakeDmg(Attack);
            }

        }
    }
}
