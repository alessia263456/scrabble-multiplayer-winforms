using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble_v4_client
{
    internal class Suport_piese
    {
        private List<Piesa> litere_suport;
       
        public Suport_piese()
        {
            litere_suport = new List<Piesa>();
            
        }
        
        public void AdaugaPiesa(Piesa p)
        {
            litere_suport.Add(p);
            
        }
        
        
        public List<char> GetLitere()
        {
            List<char> listaLitere=new List<char>();
            foreach (Piesa p in litere_suport)
                listaLitere.Add(p.GetLitera());
            return listaLitere;
        }
        
        public void ScoateLitera(int i)
        {
            litere_suport.RemoveAt(i);
           
        }
        public void AfiseazaSuport()
        {
            Console.WriteLine("suport: ");
            foreach (Piesa p in litere_suport)
            {
                Console.Write(p.GetLitera());
            }
            Console.WriteLine();
        }


    }
}
