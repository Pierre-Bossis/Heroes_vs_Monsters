﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Heroes_Vs_Monsters.Models
{
    internal abstract class Monstre : Personnage
    {
        #region Properties
        public override int Or { get; set; }
        public virtual int Cuir { get; set; }
        #endregion

        #region Constructor
        public Monstre()
        {
            Or = De.De6();
            X = De.DeStart();
            Y = De.DeStart();
        }
        #endregion
    }
}
