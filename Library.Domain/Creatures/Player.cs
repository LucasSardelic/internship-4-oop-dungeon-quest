namespace Library.Domain.Creatures
{
    public class Player:Creature
    {
        public Player()
        {
            Attack = 100;
        }

        public int PlayerAttack()
        {
            int attackType = 0;
            PlayerSkill();
            if (!Stunned)
            {
                Console.WriteLine("What is your next move?\n\t1-Direct attack\n\t2-Side attack\n\t3-Counter");

                do
                {
                    if (int.TryParse(Console.ReadLine(), out attackType) && attackType > 0 && attackType < 4)
                        break;
                    Console.WriteLine("Enter a correct number");
                } while (true);
            }
            
            return attackType;
            
        }
        public virtual void PlayerSkill() { }
        public virtual void PlayerDmg(Enemy enemy){}
    }
}
