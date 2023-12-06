
namespace Library.Domain.Creatures.EnemyType
{
    public class Brute:Enemy
    {
        public Brute()
        {
            XpValue = 70;
            Attack = 50;
            Name = "brute";
        }
        public override void EnemyDmg(Player player, Dictionary<int, (string, int, int)> dungeonFloors, int floor)
        {
            var randomNum = new Random();
            int randomState = randomNum.Next(10);
            if (randomState == 9)
            {
                Console.WriteLine("The brute deals a massive blow! you lose 25% of your max HP");
                player.TakeDmg(player.MaxHP/4);
            }
            else
            {
                player.TakeDmg(Attack);
            }

        }
    }
}
