using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes_Vs_Monsters.Models
{
    internal abstract class Personnage
    {
        #region Properties
        public int Endurance { get; private set; }
        public int BonusRacialEndurance { get; private set; }
        public int Force { get; private set; }
        public int BonusRacialForce { get; private set; }
        public int HP { get; protected set; }
        public virtual int Or { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        #region Constructor
        public Personnage()
        {

            Force = Initialise_Force_Endurance();
            Endurance = Initialise_Force_Endurance();
            int end = Endurance + BonusRacialEndurance;
            HP = end  < 5 ? Endurance - 1 : end < 10 ? Endurance + 0 : end < 15 ? Endurance + 1 : Endurance + 2;
        }
        #endregion

        #region Methods
        private int Initialise_Force_Endurance()
        {
            List<int> list = new();
            int numb = 0;

            for (int i = 0; i < 4; i++)
            {
                list.Add(De.De6());
            }

            for (int i = 0; i < 3; i++)
            {
                numb += list.Max();
                list.Remove(list.Max());
            }

            return numb;
        }

        protected void BonusRacial(int bonusForce, int bonusEndurance)
        {
            if (bonusForce == null) bonusForce = 0;
            if(bonusEndurance == null) bonusEndurance = 0;
            BonusRacialForce += bonusForce;
            BonusRacialEndurance += bonusEndurance;
        }

        public void Frappe(Personnage personnage)
        {
            int bonusForce = Force < 5 ? -1 : Force < 10 ? 0 : Force < 15 ? 1 : 2;
            int damage = De.De6() + bonusForce + BonusRacialForce;

            personnage.HP -= damage;
            Console.WriteLine($"{personnage.GetType().Name}  -{damage}HP");
        }
        #endregion
    }
}
