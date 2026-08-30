using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble_v4_server
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
        public void setNume(string mnume)
        {
            nume = mnume;
        }
        public string getNume()
        {
            return nume;
        }
        public void addScor(int mscor)
        {
            scor += mscor;
        }
        public int GetScor()
        {
            return scor;
        }
        public void AdaugaListaPiese(List<Piesa> piese)
        {
            suport.AdaugaListaPiese(piese);
        }
        public void AdaugaPiesa(Piesa p)
        {
            suport.AdaugaPiesa(p);
        }
        public void ScoatePiesaDePeSuport(int i)
        {
            if (i >= 0 && i < suport.GetNrBucati())
                suport.ScoateLitera(i);
        } 
        public void ScoatePiesaDePeSuport(char litera)
        {
            suport.ScoateLitera(litera);
        }
        public List<char> GetLitereSuport()
        {
            suport.AfiseazaSuport();
            return suport.GetLitere();
        }
        public int NrLitereSuport()
        {
            return suport.GetNrBucati();
        }
        public void afiseazaSuport()
        {
            suport.AfiseazaSuport();
        }
    }
}
