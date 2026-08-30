using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble_v4_server
{
    internal class Patrat
    {
        protected int x, y;
        protected Piesa piesa;
        
        public Patrat(int mx,int my)
        {
            x = mx;
            y = my;
            piesa = null;
        }
        public Patrat(int mx,int my, char p)
        {
            x = mx;
            y = my;
            piesa = new Piesa(p);
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }

        public char GetLitera()
        {
            return piesa.getLitera();
        }

        public Piesa GetPiesa()
        {
            return piesa;
        }
        public virtual int GetBonusLitera()
        {
            return 1;
        }
        public virtual int GetBonusCuvant()
        {
            return 1;
        }

        public void PunePiesa(int mx, int my, char p)
        {
            x = mx;
            y = my;
            piesa = new Piesa(p);
        }

        
        public bool ArePiesa()
        {
            return (piesa != null);
        }

        
    }
}
