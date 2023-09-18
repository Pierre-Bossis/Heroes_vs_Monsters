using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes_Vs_Monsters.Models
{
    internal class Loup : Monstre
    {
        public override int Cuir { get; set; }
        public Loup()
        {
            Cuir = De.De4();
        }
    }
}
