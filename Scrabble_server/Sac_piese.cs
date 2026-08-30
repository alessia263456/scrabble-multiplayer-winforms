using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble_v4_server
{
    internal class Sac_piese
    {
        private List<Piesa> sac = new List<Piesa>();
        Random rand = new Random();
        public Sac_piese() 
        {
            AdaugaPiese('A', 11);
            AdaugaPiese('B', 2);
            AdaugaPiese('C', 5);
            AdaugaPiese('D', 4);
            AdaugaPiese('E', 9);
            AdaugaPiese('F', 2);
            AdaugaPiese('G', 2);
            AdaugaPiese('H', 1);
            AdaugaPiese('I', 10);
            AdaugaPiese('J', 1);
            AdaugaPiese('L', 4);
            AdaugaPiese('M', 3);
            AdaugaPiese('N', 6);
            AdaugaPiese('O', 5); 
            AdaugaPiese('P', 4);
            AdaugaPiese('R', 7);
            AdaugaPiese('S', 5);
            AdaugaPiese('T', 7);
            AdaugaPiese('U', 6);
            AdaugaPiese('V', 2);
            AdaugaPiese('X', 1);
            AdaugaPiese('Z', 1);
            //total : 98
        }

        private void AdaugaPiese(char litera, int nr_bucati)
        {
            for (int i = 0; i < nr_bucati; i++)
            {
                sac.Add(new Piesa(litera));
            }
        }
        private Piesa ScoatePiesaRandom()
        {
            Piesa p;
            int index = rand.Next(0, sac.Count);
            p = sac[index];
            sac.RemoveAt(index);
            return p;
        }
        public List<Piesa> Scoate_n_Piese_Randon(int n)
        {
            List<Piesa> piese_extrase = new List<Piesa>();

            for (int i = 0; i < n && sac.Count > 0; i++)
                piese_extrase.Add(ScoatePiesaRandom());

            return piese_extrase;
        }
        public int getNumarPiese()
        {
            return sac.Count;
        }
    }
}
