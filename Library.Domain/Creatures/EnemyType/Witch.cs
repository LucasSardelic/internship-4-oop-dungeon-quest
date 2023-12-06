namespace Library.Domain.Creatures.EnemyType
{
    public class Witch:Enemy
    {
        public Witch()
        {
            Size = "medium";
            Attack = "strong";
            Name = "witch";
        }

        public override void EnemyDmg(Player player)
        {
            var randomNum = new Random();
            if (randomNum.Next(10) == 9)
            {
                Console.WriteLine("Witch cast: soul pocus spell!");
                player.TakeDmg("brute");
            }
            else
            {
                var SoulPocus = new Random();
                player.CurrentHP = SoulPocus.Next(1, player.MaxHP);
            }

        }
    }
}
