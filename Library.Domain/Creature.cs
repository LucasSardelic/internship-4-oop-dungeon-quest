using Library.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Library.Domain
{
    public class Creature
    {
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int Attack { get; set; }
        public string Name {  get; set; }
        public int XpValue {  get; set; }
        public bool Stunned {  get; set; }=false;
        public bool SecondDeath { get; set; } = false;
        public int MaxMP { get; set; } = 100;
        public int CurrentMP { get; set; } = 100;
        public int CurrentLvl { get; set; } = 1;
        public int CurrentXp { get; set; } = 0;
        public int Crit { get; set; } = 90;
        public int Stun { get; set; } = 90;



        public void TakeDmg(int dmg)
        {
            CurrentHP -= dmg;
        }

        public bool CheckIsAlive()
        {
            if(CurrentHP<=0)
                return false;
            else
                return true;
        }
    }
}
