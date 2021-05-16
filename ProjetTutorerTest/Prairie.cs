using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetTutorerTest
{   /*
        Class Prairie, cette class se construit à partir d'un tableau de piquet représentant tout les piquets de la prairie,
        les attributs sont en private car on a nullement les besoin pour le moment de faire appel au attribut en dehors de la class
        on implement la methode ToString ainsi que la fonction AirPrairie qui retourne l'air de la prairie
     */
    public class Prairie
    {
        private int m_nbPiquet;

       
        /*
         * On crée 4 variables pour pouvoir réaliser des calcules d'appartenance de la vache dans la prairie.
         * 
         *      -m_coordonnerTab -> correspond au coordonner des vecteurs créer avec les piquets de la prairie.
         *      -m_produitScalaire -> correspond au produit scalaire obtenue avec les piquets de la prairie.
         *      -m_norme -> correspond au norme obtenue avec les piquets de la prairie.
         *      -m_determinant -> permet de calculer le determeniant avec les piquets de la prairie.
         **/

        private double[][] m_coordonnerTab;
        private double[] m_produitScalaire;
        private double[] m_norme;
        private double[] m_determinant;

        private Piquet[] m_tabPiquet;

       /*
        * Constucteur de la classe Prairie, le constructeur est
        * basique, il faut le nombre de piquet créer ainsi que
        * les coordonnées des piquets, c'est pour cela qu'elle prend
        * un tableau de Piquet en paramètre.
        */
        public Prairie( Piquet[] p_tabPiquet)
        {
            m_nbPiquet = p_tabPiquet.Length;
            m_tabPiquet = p_tabPiquet;
        }

        override
        public string ToString()
        {
            return String.Format("nombre de piquet: {0}",m_nbPiquet);
        }

        //Calcule de l'air de la prairie.
        public double AirPrairie()
        {
            double somme = 0;
            
            /*
             * on realise une boucle dans laquelle à chaque itération on fais la somme 
             * du resultat du calcul : 
             *         AbscissePiquet1 * OrdonnerPiquet2 - AbscissePiquet2 * OrdonnerPiquet1
             *         
             * Cette boucle est utilisé pour tout les piquets sauf le dernier qu'on dois 
             * raccorder au premier piquet
             */

            for (int idxNbPiquet = 0; idxNbPiquet < m_nbPiquet-1; idxNbPiquet++)
            {
                somme += m_tabPiquet[idxNbPiquet].Abscise*m_tabPiquet[idxNbPiquet+1].Ordonner 
                    - (m_tabPiquet[idxNbPiquet+1].Abscise*m_tabPiquet[idxNbPiquet].Ordonner);   
            }

            //meme calcule que prècedement mais pour le dernier piquet relier au piquet 1
            somme += m_tabPiquet[m_nbPiquet-1].Abscise * m_tabPiquet[0].Ordonner - (m_tabPiquet[0].Abscise * m_tabPiquet[m_nbPiquet-1].Ordonner);

            double aire = somme /2;

            return aire;
        }


        /*
         * calcule de l'abscise du centre de gravité en parametre, on prend l'aire de la prairie.
         *
         */
        public double CentreGraviteAbscise(double airePrairie)
        {
            double somme = 0;
            /*
             * On itère le nombre de piquet -1
             * dans l'itération on realise la somme des resultats du calcule:
             *    AbscisePiquet1 * OrdonnerPiquet2 * (AbscisePiquet1*OrdonnerPiquet2-
             *    AbscisePiquet2 * OrdonnerPiquet1)
             *    
             * On réalise le calcule pour n-1 piquet car le piquet n est en lien avec
             * le piquet 1 donc le calcule ne fonctionne pas
             */

            for (int idx = 0; idx < m_nbPiquet - 1; idx++)
            {
                somme += (m_tabPiquet[idx].Abscise + m_tabPiquet[idx + 1].Abscise) * 
                            (m_tabPiquet[idx].Abscise * m_tabPiquet[idx+1].Ordonner - 
                            m_tabPiquet[idx + 1].Abscise * m_tabPiquet[idx].Ordonner);
                
            }

            /*
             * le calcule est identique sauf qu'on realise le calcule uniquement pour le dernier piquet
             * et le premier piquet 
             */
            
            somme += (m_tabPiquet[m_nbPiquet-1].Abscise + m_tabPiquet[0].Abscise)*
                    (m_tabPiquet[m_nbPiquet-1].Abscise*m_tabPiquet[0].Ordonner -
                    m_tabPiquet[0].Abscise*m_tabPiquet[m_nbPiquet-1].Ordonner) ;

            double AbsciseGravite = somme / (6*airePrairie);

            return AbsciseGravite;
        }

        /*
         * calcule de l'ordonner du centre de gravité en parametre, on prend l'aire de la prairie.
         *
         */
        public double CentreGraviteOrdonner(double airePrairie)
        {
            double somme = 0;

            /*
             * On réalise une itération du nombre de piquet moins 1
             * dans laquelle on realise la somme du resultat du calcule:
             *      (OrdonnerPiquet1+OrdonnerPiquet2) * 
             *      (AbscissePiquet1 * OrdonnerPiquet2 - abscisePiquet2 
             *      * OrdonnerPiquet1)
             *      
             * On realise ce calcule pour tout les piquet sauf le dernier 
             * qui n'est pas relier au piquet n+1 mais au premier
             */
            for (int idxNbPiquet = 0; idxNbPiquet < m_nbPiquet - 1; idxNbPiquet++)
            {
                somme += (m_tabPiquet[idxNbPiquet].Ordonner + m_tabPiquet[idxNbPiquet + 1].Ordonner) 
                            *(m_tabPiquet[idxNbPiquet].Abscise * m_tabPiquet[idxNbPiquet+1].Ordonner 
                            - m_tabPiquet[idxNbPiquet + 1].Abscise * m_tabPiquet[idxNbPiquet].Ordonner);

            }

            //meme calcule mais pour le dernier piquet relier au premier 
            somme += (m_tabPiquet[m_nbPiquet - 1].Ordonner + m_tabPiquet[0].Ordonner) * (m_tabPiquet[m_nbPiquet-1].Abscise * m_tabPiquet[0].Ordonner - m_tabPiquet[0].Abscise * m_tabPiquet[m_nbPiquet - 1].Ordonner);
            double OrdonnerGravite = somme / (6*airePrairie);

            return OrdonnerGravite;
        }

    
        /*
         * Calcule des coordonnée des vecteurs, la méthode prend en 
         * paramètre l'air de la prairie
         */
        public void  CoordonneVecteur(double airPrairie)
        {
            //on recupère l'abscise et l'ordonner du centre de gravité
            double AbsciseGravite = CentreGraviteAbscise(airPrairie);
            double ordonnerGravite = CentreGraviteOrdonner(airPrairie);
           
            // on initialise le tableau m_coordonnerTab
            m_coordonnerTab = new double[m_nbPiquet][];

            /*
             * on realise une boucle nb_piquet, a chaque itération,
             * on réalise la somme des resultats du calcule de coordonnée
             * du vecteur.
             */

            for (int idx = 0; idx < m_nbPiquet; idx++)
            {
                m_coordonnerTab[idx] = new double[2];
                m_coordonnerTab[idx][0] = m_tabPiquet[idx].Abscise - AbsciseGravite;
                m_coordonnerTab[idx][1] = m_tabPiquet[idx].Ordonner - ordonnerGravite;
               
              
            }
            
           

        }


        //calcule du Produit scalaire
        public void ProduitScalaire()
        {   
             //on initialise le tableau
             m_produitScalaire = new double[m_nbPiquet];
            

            //on realise une itération le nombre de piquet
            for (int idxNbPiquet = 0; idxNbPiquet < m_nbPiquet; idxNbPiquet++)
            {
     
                //si l'on est dans les piquet compris entre  et m_nbPiquet-1 on  realise ce calcule
                if (idxNbPiquet == m_nbPiquet-1)
                {
                    m_produitScalaire[idxNbPiquet] = m_coordonnerTab[idxNbPiquet][0] * m_coordonnerTab[0][0] 
                        + m_coordonnerTab[idxNbPiquet][1] * m_coordonnerTab[0][1];
                }
                //sinon si on est dans le cas du dernier piquet on le relis au premier piquet
                else
                {
                    m_produitScalaire[idxNbPiquet] = m_coordonnerTab[idxNbPiquet][0] * 
                        m_coordonnerTab[idxNbPiquet + 1][0] + m_coordonnerTab[idxNbPiquet][1] *
                        m_coordonnerTab[idxNbPiquet + 1][1];
                }

   
            }
      

        }


        // calcule de la norme d'un vecteur
        public void NormeVecteur()
        {   
            //on initialise le tableau m_norme
            m_norme = new double[m_nbPiquet ];

            // on realise une boucle m_nbPiquet fois
            for (int idx = 0; idx < m_nbPiquet ; idx++)
            {   
                // Math.Pow permet de mettre à la puissance et fonctionne comme ceci: Math.Pow ( valeur, puissance )
                double somme = Math.Pow(m_coordonnerTab[idx][1], 2) + Math.Pow(m_coordonnerTab[idx][0], 2);

                //on realise la racine carré du calcule précedent avec Math.Sqrt
                m_norme[idx] = Math.Sqrt(somme);
            }

        }

        //calcule du déterminant du vecteur
        public void DeterminantVecteur()
        {   
            //on initialise le tableai m_dterminant avec le nombre de piquet
            m_determinant = new double[m_nbPiquet ];

            // on realise une boucle m_nbPiquet fois
            for (int idx = 0; idx < m_nbPiquet ; idx++)
            {
                //si l'on est dans les piquet compris entre  et m_nbPiquet-1 on  realise ce calcule
                if (idx == m_nbPiquet - 1)
                {
                    m_determinant[idx] = m_coordonnerTab[idx][0] * m_coordonnerTab[0][1] 
                        - m_coordonnerTab[idx][1] * m_coordonnerTab[0][0];
                }
                //sinon si on est dans le cas du dernier piquet on le relis au premier piquet
                else
                {
                    m_determinant[idx] = m_coordonnerTab[idx][0] * m_coordonnerTab[idx + 1][1] 
                        - m_coordonnerTab[idx][1] * m_coordonnerTab[idx + 1][0];
                }
            }
        }


        //calcule de la somme des angles 
        public double SommeAngles()
        {
            double somme = 0;
            double angle;
            double calculeAngle;

            //on fais appel au fonction créer precedement
            ProduitScalaire();
            NormeVecteur();
            DeterminantVecteur();
            
            //on realise une boucle m_nbPiquet fois 
            for (int idx = 0; idx < m_nbPiquet ; idx++)
            {   

                //si l'on est dans les piquet compris entre  et m_nbPiquet-1 on  realise ce calcule
                if (idx == m_nbPiquet-1)
                {
                    calculeAngle = m_produitScalaire[idx] / (m_norme[idx] * m_norme[0]);
                }
                //sinon si on est dans le cas du dernier piquet on le relis au premier piquet
                else
                {
                    calculeAngle = m_produitScalaire[idx] / (m_norme[idx] * m_norme[idx + 1]);
                }
                
                //On calcule l'arccos du resultat du calcule precedent avec la methode Math.Acos
                angle = Math.Acos(calculeAngle);

                //si le déterminant est negatif alors 
                if (m_determinant[idx]<0)
                {   
                    //alors l'angle est négatif 
                    angle = -angle;
                }
                //sinon l'angle ne change pas 


                somme += angle;
              
            }

            return somme;

          
        }
    }
}

