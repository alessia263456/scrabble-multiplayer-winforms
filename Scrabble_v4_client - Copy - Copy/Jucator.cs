using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble_v4_client
{
    internal class Jucator
    {
        private string nume;
        private int scor;
        private Suport_piese suport;

        public Jucator(string mnume)
        {
            scor = 0;
            nume = mnume;
            suport=new Suport_piese();
        }
        public string GetNume()
        {
            return nume;
        }
        public int GetScor()
        {
            return scor;
        }
        public void SetScor(int mscor)
        {
            scor = mscor;
        }
        public void AdaugaPiesa(Piesa p)
        {
            suport.AdaugaPiesa(p);
        }
        public void ScoatePiesaDePeSuport(int i)
        {
            suport.ScoateLitera(i);
        }
        public List<char> GetLitereSuport()
        {
            suport.AfiseazaSuport();
            return suport.GetLitere();
        }

        
    }
}
