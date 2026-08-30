using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble_v4_server
{
    enum Directie
    {
        Invalida,
        Orizontala,
        Verticala
    }
    internal class Joc
    {

        private const int LUNGIME = 15;
        private const int LATIME = 15;
        private Tabla_Joc tabla;
        private Sac_piese sac;
        private Jucator[] jucatori;
        private Mutare mutareCurenta;
        private Dictionar dictionar;
        public Joc()
        {
            tabla = new Tabla_Joc(LUNGIME, LATIME);
            jucatori = new Jucator[2];
            jucatori[0]= new Jucator("Player 1");
            jucatori[1]= new Jucator("Player 2");
            sac = new Sac_piese();
            mutareCurenta = new Mutare();
            dictionar = new Dictionar("Dictionar.txt");
        }
        public Jucator GetJucator(int n)
        {
            return jucatori[n];
        }
        public List<char> GetPieseNoi(Jucator j, int nrPiese)
        {
            List<Piesa> piese = sac.Scoate_n_Piese_Randon(nrPiese);
            j.AdaugaListaPiese(piese);
            List<char> litere = new List<char>();
            foreach (Piesa p in piese)
                litere.Add(p.getLitera());
            return litere;
        }
        public int GetNrLitereInSac()
        {
            return sac.getNumarPiese();
        }
        public Mutare GetMutareCurenta()
        {
            return mutareCurenta;
        }
        public string GetStringTransmitereMutareCurenta()
        {
            return mutareCurenta.GetMutarea();
        }
        public char GetLiteraPlasataLaPozitie(Mutare mutare, int i, int j)
        {

            if (mutare.VerificaPlasare(i, j))
            {
                return mutare.GetLiteraPlasataLaPozitie(i, j);
            }
            if (tabla.PatratArePiesa(i, j))
            {
                return tabla.getLitera(i, j);
            }
            return ' ';
        }
        public void StergeUltimaLiteraPlasata()
        {
            mutareCurenta.StergeUltimaLitera();
        }
        
        public void AdaugaLaMutareCurenta(int i, int j, char litera)
        {
            
            mutareCurenta.AdaugaPiesa(new Patrat(i, j, litera));
            mutareCurenta.AfiseazaMutare();
        }
        public void PunePiesaPeTabla(int i, int j, char litera)
        {
            tabla.PunePiesa(i,j, litera);
        }
        public void PuneMutareaPeTabla(Mutare mutare)
        {
            foreach (Patrat p in mutare.GetListaPlasate())
                PunePiesaPeTabla(p.GetX(), p.GetY(), p.GetLitera());
        }

        public void ClearMutareCurenta()
        {
            mutareCurenta.ClearMutare();
        }

       
        private bool SuntPieseContinue(Mutare mutare)
        {
            List<Patrat> plasari = mutare.GetListaPlasate();

            if (mutare.CountPlasari() == 0)
                return false;

            Directie dir = mutare.DeterminaDirectie();
            if (dir == Directie.Invalida)
                return false;

      
            if (mutare.CountPlasari() == 1)
                return true;

            if (dir == Directie.Orizontala)
            {
                int linie = plasari[0].GetX();
                int colMin = 20;
                int colMax = -1;
                foreach (Patrat p in plasari)
                {
                    if(p.GetY()<colMin)
                        colMin = p.GetY();
                    if(p.GetY()>colMax)
                        colMax = p.GetY();
                }
                for (int col = colMin; col <= colMax; col++)
                {
                    if (!AreLitera(mutare, linie, col)) 
                        return false; 
                }
            }
            else 
            {
                int col = plasari[0].GetY();
                int linieMin = 20;
                int linieMax = -1;
                foreach (Patrat p in plasari)
                {
                    if (p.GetX() < linieMin)
                        linieMin = p.GetX();
                    if (p.GetX() > linieMax)
                        linieMax = p.GetX();
                }
                for (int linie = linieMin; linie <= linieMax; linie++)
                {
                    if (!AreLitera(mutare, linie,col))
                        return false;
                }
            }

            return true;
        }

       

        private bool AreLitera(Mutare mutare, int i, int j)
        {
            if(mutare.VerificaPlasare(i, j) )
            {
                return true;
            }
            if(tabla.PatratArePiesa(i,j))
            {
                return true;
            }
            return false;
        }
        
        private string ConstruiesteCuvantOrizontal(Mutare mutare,int x, int y)
        {
            int col = y;

            while (col > 1 && AreLitera(mutare,x,col-1))
                col--;

            string cuvant = "";

            while (col <= LATIME && AreLitera(mutare, x, col))
            {
                cuvant += GetLiteraPlasataLaPozitie(mutare, x,col);
                col++;
            }

            return cuvant;
        }

        private string ConstruiesteCuvantVertical(Mutare mutare,int x, int y)
        {
            int linie = x;

            while (linie > 1 && AreLitera(mutare, linie - 1, y))
                linie--;

            string cuvant = "";

            while (linie <= LUNGIME && AreLitera(mutare, linie, y))
            {
                cuvant+= GetLiteraPlasataLaPozitie(mutare, linie,y);
                linie++;
            }

            return cuvant;
        }


        private bool ValideazaCuvinteDictionar(Mutare mutare)
        {
            List<Patrat> plasari = mutare.GetListaPlasate();
            if (plasari.Count == 0)
                return false;

            Patrat p0 = plasari[0];
            Directie directie = mutare.DeterminaDirectie();

            string cuvantOrizontal = ConstruiesteCuvantOrizontal(mutare,p0.GetX(), p0.GetY());
            string cuvantVertical = ConstruiesteCuvantVertical(mutare,p0.GetX(), p0.GetY());

            if (cuvantOrizontal.Length > 1 && !dictionar.CuvantValid(cuvantOrizontal))
                return false;
            if (cuvantVertical.Length > 1 && !dictionar.CuvantValid(cuvantVertical))
                return false;

            foreach (Patrat p in plasari)
            {
                string cuvantSecundar = "";
                if (directie == Directie.Orizontala)
                    cuvantSecundar = ConstruiesteCuvantVertical(mutare,p.GetX(), p.GetY());
                else
                    cuvantSecundar = ConstruiesteCuvantOrizontal(mutare, p.GetX(), p.GetY());

                if (cuvantSecundar.Length > 1 && !dictionar.CuvantValid(cuvantSecundar))
                    return false;
            }

            return true;
        }


        private bool ConectataLaTabla(Mutare mutare)
        {
            if (tabla.TablaEsteGoala())
                return true;
            foreach (Patrat p in mutare.GetListaPlasate())
            {
                int x = p.GetX();
                int y = p.GetY();

                if (x > 1 && tabla.PatratArePiesa(x - 1, y)) return true;
                if (x <LUNGIME && tabla.PatratArePiesa(x + 1, y)) return true;
                if (y > 1 && tabla.PatratArePiesa(x, y - 1)) return true;
                if (y < LATIME && tabla.PatratArePiesa(x, y + 1)) return true;

            }
            return false;
        }

        private bool ValideazaPrimaMutare(Mutare mutare)
        {
            if (!tabla.TablaEsteGoala())
                return true;
            if (mutare.CountPlasari() <= 1)
                return false;
            if (mutare.VerificaPlasare(8, 8))
                return true;
            return false;
        }
        public bool MutareValida(Mutare mutare)
        {
            if (tabla.TablaEsteGoala() && !ValideazaPrimaMutare(mutare))
            {
                Console.WriteLine("Prima mutare");
                return false;
            }
            if (mutare.DeterminaDirectie() == Directie.Invalida)
            {
                Console.WriteLine("Directie invalida");
                return false;
            }
            
            if (!SuntPieseContinue(mutare))
            {
                Console.WriteLine("Nu sunt continue");
                return false;
            }
            if (!ConectataLaTabla(mutare))
            {
                Console.WriteLine("Nu e conectat la tabla");
                return false;
            }
            if (!ValideazaCuvinteDictionar(mutare))
            {
                Console.WriteLine("Cuvant invalid");
                return false;
            }
            
            return true;
        }

        public List<Patrat> GetListaPlasateMutareCurenta()
        {
            return mutareCurenta.GetListaPlasate();
        }
        private List<Patrat> PozitiiCuvantOrizontal(Mutare mutare, int x, int y)
        {
            List<Patrat> pozitii = new List<Patrat>();
            int col = y;
            while (col > 1 && AreLitera(mutare, x, col - 1))
                col--;
            while (col <= LATIME && AreLitera(mutare, x, col))
            {
                pozitii.Add(new Patrat(x, col, GetLiteraPlasataLaPozitie(mutare, x, col)));
                col++;
            }
            return pozitii;
        }
        private List<Patrat> PozitiiCuvantVertical(Mutare mutare, int x, int y)
        {
            List<Patrat> pozitii = new List<Patrat>();
            int linie = x;
            while (linie > 1 && AreLitera(mutare, linie - 1, y))
                linie--;
            while (linie <= LUNGIME && AreLitera(mutare, linie, y))
            {
                pozitii.Add(new Patrat(linie, y, GetLiteraPlasataLaPozitie(mutare, linie, y)));
                linie++;
            }
            return pozitii;
        }

        private int CalculeazaScorCuvant(Mutare mutare,List<Patrat> ListaPozitii)
        {
            int scor = 0;
            int multiplicatorCuvant = 1;
            Console.Write("Cuvant: ");
            foreach (Patrat p in ListaPozitii)
            {
                Console.Write(p.GetLitera());
                Piesa piesa=p.GetPiesa();
                int valoare = piesa.getPunctaj();
                if(mutare.VerificaPlasare(p.GetX(),p.GetY()))
                {
                    valoare *= tabla.getMultiplicatorLitera(p.GetX(),p.GetY());
                    multiplicatorCuvant *= tabla.getMultiplicatorCuvant(p.GetX(), p.GetY());

                }
                scor += valoare;
            }
            Console.WriteLine();
            Console.WriteLine("scor cuvant: " + scor);
            Console.WriteLine("multiplicator cuvant: " + multiplicatorCuvant);
            Console.WriteLine("Scor Cuvant total: " + scor*multiplicatorCuvant);
            return scor * multiplicatorCuvant;
        }

        

        public int CalculeazaScorMutare(Mutare mutare)
        {
            int scorTotal = 0;
            List<Patrat> plasari = mutare.GetListaPlasate();
            Directie dir = mutare.DeterminaDirectie();
            Patrat p0 = plasari[0];

            List<Patrat> pozitiiCuvantPrincipal = new List<Patrat>();
            if (dir == Directie.Orizontala)
                pozitiiCuvantPrincipal = PozitiiCuvantOrizontal(mutare,p0.GetX(), p0.GetY());
            else
                pozitiiCuvantPrincipal = PozitiiCuvantVertical(mutare, p0.GetX(), p0.GetY());

            if (pozitiiCuvantPrincipal.Count > 1)
                scorTotal += CalculeazaScorCuvant(mutare,pozitiiCuvantPrincipal);

            List<Patrat> pozitiiCuvinteSecundare = new List<Patrat>();
            foreach (Patrat p in plasari)
            {
                if (dir == Directie.Orizontala)
                    pozitiiCuvinteSecundare = PozitiiCuvantVertical(mutare, p.GetX(), p.GetY());
                else
                    pozitiiCuvinteSecundare = PozitiiCuvantOrizontal(mutare, p.GetX(), p.GetY());

                if (pozitiiCuvinteSecundare.Count > 1)
                    scorTotal += CalculeazaScorCuvant(mutare, pozitiiCuvinteSecundare);
            }
            Console.WriteLine("scor total: " + scorTotal);

            return scorTotal;
        }
        
        public void AdaugaScorMutare(Jucator j,Mutare mutare)
        {
            int scor=CalculeazaScorMutare(mutare);
            j.addScor(scor);
        }

       
        public void AfiseazaMatriceLitere()
        {
            tabla.AfiseazaMatriceLitere();
        }
    }
}
