using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble_v4_server
{
    internal class Suport_piese
    {
        private List<Piesa> litere_suport;
        public Suport_piese()
        {
            litere_suport = new List<Piesa>();
        }
        public void AdaugaListaPiese(List<Piesa> piese_extrase)
        {
            for (int i = 0; i < piese_extrase.Count; i++)
            {
                litere_suport.Add(new Piesa(piese_extrase[i]));
            }
        }
        public void AdaugaPiesa(Piesa p)
        {
            litere_suport.Add(p);
        }
        
        public int GetNrBucati()
        {
            return litere_suport.Count;
        }
        public List<char> GetLitere()
        {
            List<char> listaLitere=new List<char>();
            foreach (Piesa p in litere_suport)
                listaLitere.Add(p.getLitera());
            return listaLitere;
        }
        
        public void ScoateLitera(int i)
        {  
            litere_suport.RemoveAt(i);
        }
        public void ScoateLitera(char litera)
        {
            int index = -1;
            for (int i = 0; i < litere_suport.Count && index==-1; i++)
                if (litere_suport[i].getLitera() == litera)
                    index = i;
            if (index != -1)
                litere_suport.RemoveAt(index);
        }
        public void AfiseazaSuport()
        {
            Console.WriteLine("suport: ");
            foreach (Piesa p in litere_suport)
            {
                Console.Write(p.getLitera());
            }
            Console.WriteLine();
        }
    }
}
