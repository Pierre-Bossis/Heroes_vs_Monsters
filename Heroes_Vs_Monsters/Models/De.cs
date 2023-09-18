using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes_Vs_Monsters.Models
{
    internal static class De
    {
        public static readonly int Minimum;
        public static readonly int Maximum;

        public static int De4()
        {
            Random rand = new();
            return rand.Next(1, 4);

        }

        public static int De6()
        {
            Random rand = new();
            return rand.Next(1, 6);
        }

        public static int DeStart()
        {
            Random rand = new();
            return rand.Next(0, 14);
        }
    }
}
