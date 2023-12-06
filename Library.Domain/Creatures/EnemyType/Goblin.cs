
using System.Drawing;

namespace Library.Domain.Creatures.EnemyType
{
    public class Goblin:Enemy
    {
        public Goblin()
        {
            XpValue = 30;
            Attack = 20;
            Name = "goblin";
        }

        public override void EnemyDmg(Player player, Dictionary<int, (string, int, int)> dungeonFloors, int floor)
        {
            player.TakeDmg(Attack);
        }
    }
}
