
using System.Drawing;

namespace Library.Domain.Creatures.EnemyType
{
    public class Goblin:Enemy
    {
        public Goblin()
        {
            Size = "small";
            Attack = "weak";
            Name = "goblin";
        }

        public override void EnemyDmg(Player player)
        {
            player.TakeDmg(Attack);
        }
    }
}
