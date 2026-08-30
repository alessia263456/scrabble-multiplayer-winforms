using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble_v4_client
{
    internal class Piesa
    {
        private char litera;
        private int punctaj;

        

        
        public Piesa(char mlitera)
        {
            litera = mlitera;
            punctaj = GetValoareLitera(mlitera);
        }
        
        public int GetValoareLitera(char mlitera)
        {
            int[] v = { 1, 5, 1, 2, 1, 4, 6, 8, 1, 10, 0, 1, 4, 1, 1, 2, 0, 1, 1, 1, 1, 4, 0, 10, 0, 8 };
            //          A  B  C  D  E  F  G  H  I  J   K  L  M  N  O  P  Q  R  S  T  U  V  W  X   Y  Z  

            return v[mlitera - 'A'];
        }
        public char GetLitera()
        {
            return litera;
        }
    }
}
