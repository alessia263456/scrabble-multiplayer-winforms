using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble_v4_client
{

    internal class Mutare
    {
        private List<Patrat> piesePlasate;
        private int nr_plasate;
        public Mutare()
        {
            piesePlasate = new List<Patrat>();
            nr_plasate = 0;
        }
        public string GetMutarea()
        {
            string mutarea = "";

            foreach (Patrat p in piesePlasate)
            {
                mutarea += p.GetLitera() + " " + p.GetX() + " " + p.GetY() + "#";
            }
            return mutarea;
        }
        public void AdaugaPiesa(Patrat patrat)
        {
            piesePlasate.Add(patrat);
            nr_plasate++;
        }
        
        public void ClearMutare()
        {
            piesePlasate.Clear();
            nr_plasate = 0;
        }

        public List<Patrat> GetListaPlasate()
        {
            return piesePlasate;
        }

       
        public void StergeUltimaLitera()
        {
            piesePlasate.RemoveAt(piesePlasate.Count - 1);
            nr_plasate--;
        }

        

    }
}
