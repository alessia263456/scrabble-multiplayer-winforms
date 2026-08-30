using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble_v4_server
{
    internal class Mutare
    {
        private List<Patrat> piesePlasate;
        private int nr_plasate;
        public Mutare()
        {
            piesePlasate=new List<Patrat>();
            nr_plasate=0;
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
        public int CountPlasari()
        {
            return nr_plasate;
        }
        public Directie DeterminaDirectie()
        {
            if(piesePlasate.Count == 0) 
                return Directie.Invalida;
            if (piesePlasate.Count == 1) 
                return Directie.Orizontala; //daca e o singura piesa nu conteaza
            int linie = piesePlasate[0].GetX();
            int coloana = piesePlasate[0].GetY();
            bool aceeasiLinie = true;
            bool aceeasiColoana = true;
            foreach(Patrat p in piesePlasate)
            {
                if (p.GetY() != coloana)
                    aceeasiColoana = false;
                if (p.GetX() != linie)
                    aceeasiLinie = false;
            }
            if (aceeasiLinie == true)
                return Directie.Orizontala;
            else if (aceeasiColoana == true)
                return Directie.Verticala;
            else return Directie.Invalida;
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

        public bool VerificaPlasare(int mx, int my)
        {
            foreach(Patrat p in piesePlasate)
            {
                if (p.GetY() == my && p.GetX() == mx)
                {
                   return true;
                }
            }
            return false;
        }

        public char GetLiteraPlasataLaPozitie(int mx, int my)
        {
            foreach (Patrat p in piesePlasate)
            {
                if (p.GetY() == my && p.GetX() == mx)
                {
                    return p.GetLitera();
                }
            }
            return ' ';
        }

        public void StergeUltimaLitera()
        {
            piesePlasate.RemoveAt(piesePlasate.Count - 1);
            nr_plasate--;
        }

        
        public void AfiseazaMutare()
        {
            foreach (Patrat p in piesePlasate)
            {
                Console.Write(p.GetLitera());
            }
            Console.WriteLine();
        }

    }
}
