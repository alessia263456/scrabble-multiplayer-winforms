using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Scrabble_v4_server
{
    internal class Dictionar
    {
        string fisier;
        string[] linii;
        public Dictionar(string numeFisier) 
        {
            fisier = numeFisier;
            linii = File.ReadAllLines(fisier);
        }
        public bool CuvantValid(string cuvant)
        {
            cuvant = cuvant.ToLower();
            foreach (string linie in linii)
            {
                if (linie == cuvant)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
