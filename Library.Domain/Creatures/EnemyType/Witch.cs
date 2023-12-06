namespace Library.Domain.Creatures.EnemyType
{
    public class Witch:Enemy
    {
        public Witch()
        {
            XpValue = 100;
            Attack = 150;
            Name = "witch";
        }

        public override void EnemyDmg(Player player, Dictionary<int, (string, int, int)> dungeonFloors, int floor)
        {
            var randomNum = new Random();
            if (randomNum.Next(10) >= 6)
            {
                Console.WriteLine("Witch cast: soul pocus spell!");
                player.CurrentHP = randomNum.Next(1, player.MaxHP);
                CurrentHP = randomNum.Next(1, MaxHP);
                for(int i=floor+1; i< dungeonFloors.Count+1; i++)
                {
                    dungeonFloors[i] = (dungeonFloors[i].Item1, dungeonFloors[i].Item2, randomNum.Next(1, dungeonFloors[i].Item2));
                }
            }
            else
            {
                player.TakeDmg(Attack);
            }

        }
    }
}
