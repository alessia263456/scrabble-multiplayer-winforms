using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble_v4_server
{
    internal class Patrat_Bonus_Cuvant: Patrat
    {
        private int bonus;
        public Patrat_Bonus_Cuvant(int mx, int my, int mbonus):base(mx,my)
        {
            bonus = mbonus;
        }
       public override int GetBonusCuvant() 
        { 
            return bonus; 
        }
    }
}
