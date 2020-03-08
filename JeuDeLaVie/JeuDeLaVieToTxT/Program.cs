using CegepVicto.TechInfo.H2020.P2.DA1934363.JeuVie;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeLaVieToTxT
{
    class Program
    {
        static void Main(string[] args)
        {
            JeuDeLaVie jeu = new JeuDeLaVie(100, 50, 50); //Création du jeu
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < 200; i++)
            {
                jeu.Transiter();
                str.AppendLine(jeu.ToString());
                str.AppendLine();
                for (int j = 0; j < 100; j++)
                {
                    str.Append("-");
                }
                str.AppendLine();
            }
            TextWriter txt = new StreamWriter("D:/JeuDeLaVie.txt",true);
            txt.Write(str.ToString());
            Console.WriteLine("Fini!");
            Console.ReadKey();
        }
    }
}
