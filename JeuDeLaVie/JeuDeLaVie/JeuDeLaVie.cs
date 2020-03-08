using System;
using System.Text;

namespace CegepVicto.TechInfo.H2020.P2.DA1934363.JeuVie
{
    public class JeuDeLaVie
    {
        private static JeuDeLaVie instance;

        private int tailleX;
        private int tailleY;
        private int chance;
        private int[,] tableauFait;
        bool transition = false;
        private bool afficherTransition=false;

        /// <summary>
        /// Créer un jeu de la vie.
        /// </summary>
        /// <param name="tailleX">La taille en X.</param>
        /// <param name="tailleY">La taille en Y.</param>
        /// <param name="chance">La chance sur 100</param>
        /// <returns>Retourne un instance du jeu.</returns>
        public static JeuDeLaVie GetInstance(int tailleX, int tailleY, int chance)
        {
            if (instance == null)
            {
                instance = new JeuDeLaVie(tailleX,tailleY,chance);
            }
            return instance;
        }




        /// <summary>
        /// Créer une instance du jeu de la vie.
        /// </summary>
        /// <param name="tailleX">La taille en X.</param>
        /// <param name="tailleY">La taille en Y.</param>
        /// <param name="chance">La chance sur 100</param>
        private JeuDeLaVie(int tailleX, int tailleY, int chance)
        {
            this.tailleX = Math.Abs(tailleX);
            this.tailleY = Math.Abs(tailleY);
            this.chance = Math.Abs(chance);
            CreationTableaux(); //Création du tableau initial
        }

        /// <summary>
        /// Création du tableau initial
        /// </summary>
        private void CreationTableaux()
        {
            tableauFait = new int[tailleX, tailleY];
            Random rnd = new Random();

            for (int i = 0; i < tailleY; i++)
            {
                for (int o = 0; o < tailleX; o++)
                {
                    int nombre = rnd.Next(0, 101);
                    int state;

                    if (nombre < chance)
                    {
                        state = 1;
                    }
                    else
                    {
                        state = 0;
                    }

                    tableauFait[o, i] = state;
                }
            }
        }
        /// <summary>
        /// Méthode qui fait le tableau de vérification pour vérifier ensuite le tableau
        /// </summary>
        public string ConstructionTableauVerif()
        {

            for (int i = 0; i < tailleY; i++)
            {
                for (int o = 0; o < tailleX; o++)
                {
                    int nbVoisin = 0;
                    int posX = o - 1;
                    int posY = i - 1;
                    //Vérification des voisins du haut
                    for (int l = 0; l < 3; l++)
                    {
                        bool isNotBelowX = posX + l >= 0;
                        bool isNotUpX = posX + l <= tailleX - 1;
                        bool isNotBelowY = posY >= 0;


                        //Vérifie si la case existe, sinon elle ne la scan pas
                        if (isNotBelowX && isNotUpX && isNotBelowY)
                        {
                            int casePosX = posX + l;
                            int casePosY = posY;
                            if (tableauFait[posX + l, posY] == 1 || tableauFait[posX + l, posY] == 4)
                            {
                                nbVoisin++;
                            }
                        }
                    }
                    //Vérification des voisins des côtés
                    for (int u = 0; u < 2; u++)
                    {
                        bool isBelowX = posX + u * 2 >= 0;
                        bool isUpX = posX + u * 2 <= tailleX - 1;

                        //Vérifie si la case existe, sinon elle ne la scan pas
                        if (isBelowX && isUpX)
                        {
                            int casePosX = posX + u * 2;
                            int casePosY = posY + 1;
                            if (tableauFait[casePosX, casePosY] == 1 || tableauFait[casePosX, casePosY] == 4)
                            {
                                nbVoisin++;
                            }
                        }
                    }
                    //Vérification des voisins en bas
                    for (int h = 0; h < 3; h++)
                    {
                        bool isNotBelowX = posX + h >= 0;
                        bool isNotUpX = posX + h < tailleX;
                        bool isNotUpY = (posY + 2) < tailleY;

                        //Vérifie si la case existe, sinon elle ne la scan pas
                        if (isNotBelowX && isNotUpX && isNotUpY)
                        {
                            int casePosX = posX + h;
                            int casePosY = posY + 2;
                            if (tableauFait[casePosX, casePosY] == 1 || tableauFait[casePosX, casePosY] == 4)
                            {
                                nbVoisin++;
                            }
                        }
                    }
                    if (tableauFait[o, i] == 1)
                    {
                        if (nbVoisin < 2 || nbVoisin > 3)
                        {
                            tableauFait[o, i] = 4;
                        }
                    }
                    if (tableauFait[o, i] == 0)
                    {
                        if (nbVoisin == 3)
                        {
                            tableauFait[o, i] = 3;
                        }
                    }
                }
            }
            return ToString();
        }

        public void Transiter()
        {
            ConstructionTableauVerif(); 
            if (!afficherTransition)
            {
                ProchainCycle();
            }
        
        }
        /// <summary>
        /// Change les valeurs du tableau pour le prochain cycle.
        /// </summary>
        public void ProchainCycle()
        {
            if (transition)
            {
                for (int i = 0; i < tailleY; i++)
                {
                    for (int o = 0; o < tailleX; o++)
                    {
                        if (tableauFait[o, i] == 1 || tableauFait[o, i] == 3)
                        {
                            tableauFait[o, i] = 1;
                        }
                        else
                        {
                            tableauFait[o, i] = 0;
                        }
                    }
                }
            }
            else
            {
                ConstructionTableauVerif();
                    
             }
            transition = !transition;
                
    }
        //Fait changer le tableau en string.
        public override string ToString()
        {
            StringBuilder stringMaker = new StringBuilder();
            int valeur;
            for (int i = 0; i < tailleY; i++)
            {
                for (int o = 0; o < tailleX; o++)
                {
                    valeur = tableauFait[o, i];
                    if (valeur == 1)
                    {
                        stringMaker.Append("▓");
                    }
                    else if (valeur == 3)
                    {
                        stringMaker.Append("▒");
                    }
                    else if (valeur == 4)
                    {
                        stringMaker.Append("x");
                    }
                    else
                    {
                        stringMaker.Append(" ");
                    }
                }
                stringMaker.Append("\n");
            }
            return stringMaker.ToString();
        }

        public bool AfficherTransition { get => afficherTransition; set => afficherTransition = value; }
    }
}
