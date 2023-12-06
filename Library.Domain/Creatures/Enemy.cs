using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            int randomState = randomNum.Next(3);
            //1-Direct, 2-Side, 3-Counter
            EnemyAttack=randomState+1;
        }
    }
}
