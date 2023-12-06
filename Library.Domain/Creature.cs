using Library.Data;
using System.Security.Cryptography.X509Certificates;

namespace Library.Domain
{
    public class Creature
    {
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }

        public void SetMaxHP()
        {
            MaxHP=100;
            CurrentHP=MaxHP;
        }

        public void TakeDmg()
        {
            CurrentHP -= 40;
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
