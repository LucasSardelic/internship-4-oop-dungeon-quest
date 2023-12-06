using Library.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Library.Domain
{
    public class Creature
    {
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public string Size {  get; set; }
        public string Attack { get; set; }
        public string Name {  get; set; }
        public bool Stunned {  get; set; }=false;
        public bool SecondDeath { get; set; } = false;
        public int MaxMP { get; set; } = 100;
        public int CurrentMP { get; set; } = 100;


        public void SetMaxHP(string size)
        {
            if (size == "small") 
                MaxHP = 50;
            else if(size=="medium")
                MaxHP = 100;
            else if(size=="large")
                MaxHP = 200;
            CurrentHP=MaxHP;
        }

        public void TakeDmg(string dmg)
        {
            if (dmg == "weak")
                CurrentHP -= 20;
            else if (dmg == "medium")
                CurrentHP -= 40;
            else if (dmg == "strong")
                CurrentHP -= 80;
            else if (dmg == "brute")
                CurrentHP -= (MaxHP/4);
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
