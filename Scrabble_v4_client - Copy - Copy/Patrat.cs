using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble_v4_client
{
    internal class Patrat
    {
        protected int x, y;
        protected Piesa piesa;
        
        
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
            return piesa.GetLitera();
        }
        
    }
}
