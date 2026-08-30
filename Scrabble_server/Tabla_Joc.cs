using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble_v4_server
{
    internal class Tabla_Joc
    {
        private int LUNGIME;
        private int LATIME;
        private bool goala;
        private Patrat[,] MatricePatrate;
        private int[,] MatriceBonus = {
            { 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
            { 0, 32,  0,  0, 21,  0,  0,  0, 32,  0,  0,  0, 21,  0,  0, 32},
            { 0,  0, 22,  0,  0,  0, 31,  0,  0,  0, 31,  0,  0,  0, 22,  0},
            { 0,  0,  0, 22,  0,  0,  0, 21,  0, 21,  0,  0,  0, 22,  0,  0},
            { 0, 21,  0,  0, 22,  0,  0,  0, 21,  0,  0,  0, 22,  0,  0, 21},
            { 0,  0,  0,  0,  0, 22,  0,  0,  0,  0,  0, 22,  0,  0,  0,  0},
            { 0,  0, 31,  0,  0,  0, 31,  0,  0,  0, 31,  0,  0,  0, 31,  0},
            { 0,  0,  0, 21,  0,  0,  0, 21,  0, 21,  0,  0,  0, 21,  0,  0},
            { 0, 32,  0,  0, 21,  0,  0,  0, 22,  0,  0,  0, 21,  0,  0, 32},
            { 0,  0, 0, 21,  0,  0,  0, 21,  0, 21,  0,  0,  0, 21,  0,  0},
            { 0,  0, 31,  0,  0,  0, 31,  0,  0,  0, 31,  0,  0,  0, 31,  0},
            { 0,  0,  0,  0,  0, 22,  0,  0,  0,  0,  0, 22,  0,  0,  0,  0},
            { 0, 21,  0,  0, 22,  0,  0,  0, 21,  0,  0,  0, 22,  0,  0, 21},
            { 0,  0,  0, 22,  0,  0,  0, 21,  0, 21,  0,  0,  0, 22,  0,  0},
            { 0,  0, 22,  0,  0,  0, 31,  0,  0,  0, 31,  0,  0,  0, 22,  0},
            { 0, 32,  0,  0, 21,  0,  0,  0, 32,  0,  0,  0, 21,  0,  0, 32}
        };

        

        public Tabla_Joc(int mLUNGIME, int mLATIME)
        {
            LUNGIME= mLUNGIME;
            LATIME= mLATIME;
            MatricePatrate = new Patrat[LUNGIME+1, LATIME+1];
            goala = true;

            for (int i=1; i<=LUNGIME; i++)
            {
                for(int j=1; j<=LATIME; j++)
                {
                    switch (MatriceBonus[i,j])
                    {
                        case 0:
                            MatricePatrate[i, j] = new Patrat(i, j);
                            break;
                        case 21:
                            MatricePatrate[i, j] = new Patrat_Bonus_Litera(i, j, 2);
                            break;
                        case 31:
                            MatricePatrate[i, j] = new Patrat_Bonus_Litera(i, j, 3);
                            break;
                        case 22:
                            MatricePatrate[i, j] = new Patrat_Bonus_Cuvant(i, j, 2);
                            break;
                        case 32:
                            MatricePatrate[i, j] = new Patrat_Bonus_Cuvant(i, j, 3);
                            break;
                    }
                }            
            }
        }
       public void PunePiesa(int i, int j, char p)
        {
            MatricePatrate[i, j].PunePiesa(i, j, p);
            goala = false;
        }
        

        public bool PatratArePiesa(int i, int j)
        {
            return (MatricePatrate[i, j].ArePiesa());
        }

        public char getLitera(int i, int j)
        {
            return MatricePatrate[i,j].GetLitera();
        }

        public bool TablaEsteGoala()
        {
            return goala;
        }
        public int getMultiplicatorLitera(int i, int j)
        {
            return MatricePatrate[i, j].GetBonusLitera();
        }
        public int getMultiplicatorCuvant(int i, int j)
        {
            return MatricePatrate[i, j].GetBonusCuvant();
        }
        public void AfiseazaMatriceLitere()
        {
            for (int i = 1; i <= LUNGIME; i++)
            {
                for (int j = 1; j <= LATIME; j++)
                {
                    if (MatricePatrate[i, j].ArePiesa())
                        Console.Write(MatricePatrate[i, j].GetLitera() + " ");
                    else
                        Console.Write("0 ");
                }
                Console.WriteLine();
            }
        }
    }
}
