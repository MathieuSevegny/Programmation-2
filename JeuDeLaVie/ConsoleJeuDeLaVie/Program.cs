using System;
using CegepVicto.TechInfo.H2020.P2.DA1934363.JeuVie;
using System.Threading;

namespace CegepVicto.TechInfo.H2020.P2.DA1934363.JeuVie
{
    class ProgramConsole
    {
        static void Main()
        {
            Console.CursorVisible = false;
            JeuDeLaVie jeu = JeuDeLaVie.GetInstance(200,50,50); //Création du jeu
            jeu.AfficherTransition = false;
            //Boucle pour l'éternité
            while (true)
            {
                Console.SetCursorPosition(0, 0); //Remet le curseur à l'origine
                jeu.Transiter();
                Console.Write(jeu); //Démarre de prochain cycle
                Thread.Sleep(5); //Attend avant de réafficher
            }
            
        }
    }
}
