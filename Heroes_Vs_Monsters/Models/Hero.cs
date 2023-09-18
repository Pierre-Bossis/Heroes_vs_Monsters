﻿namespace Heroes_Vs_Monsters.Models
{
    internal abstract class Hero : Personnage
    {
        public int MaxHP { get; set; }
        public int NbCuir { get; set; }
        public Hero()
        {
            Or = 0;
            NbCuir = 0;
            MaxHP = HP;
            X = 8;
            Y = 14;
        }

        public void Frappe(Monstre monstre)
        {
            base.Frappe(monstre);
            
            if(monstre.HP <= 0)
            {
                Or += monstre.Or;
                if(monstre.GetType().Name == "Loup" || monstre.GetType().Name == "Dragonnet")
                {
                    NbCuir += monstre.Cuir;
                }
            }
        }

        public void SeReposer()
        {
            HP = MaxHP;
        }
    }
}
