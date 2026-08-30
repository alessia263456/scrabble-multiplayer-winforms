using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble_v4_server
{
    internal class Patrat_Bonus_Litera : Patrat
    {
        private int bonus;
        public Patrat_Bonus_Litera(int mx, int my, int mbonus):base(mx,my)
        {
            this.bonus = mbonus;
        }
        public override int GetBonusLitera()
        { return bonus; }
    }
}
