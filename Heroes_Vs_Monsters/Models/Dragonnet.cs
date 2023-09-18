using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes_Vs_Monsters.Models
{
    internal class Dragonnet : Monstre
    {
        public override int Cuir { get; set; }
        public Dragonnet()
        {
            BonusRacial(0, 1);
            Cuir = De.De4();
        }

    }
}
