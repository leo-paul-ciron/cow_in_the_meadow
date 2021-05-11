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

        private double[][] m_coordonnerTab;
        
        private double[] m_produitScalaire;
        private double[] m_norme;
        private double[] m_determinant;
        public int NbPiquet
        {
            get { return m_nbPiquet; }
        }

        private Piquet[] m_tabPiquet;

        public double CoordonnerPiquet
        {
            get { return m_tabPiquet[0].Ordonner; }
        }
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

        public double AirPrairie()
        {
            double somme = 0;
            
            for (int idx = 0; idx < m_nbPiquet-1; idx++)
            {
                somme += m_tabPiquet[idx].Abscisse*m_tabPiquet[idx+1].Ordonner - (m_tabPiquet[idx+1].Abscisse*m_tabPiquet[idx].Ordonner);   
            }

            somme += m_tabPiquet[m_nbPiquet-1].Abscisse * m_tabPiquet[0].Ordonner - (m_tabPiquet[0].Abscisse * m_tabPiquet[m_nbPiquet-1].Ordonner);

            double aire = somme /2;

            return aire;
        }

        public double CentreGraviteAbscisse(double airePrairie)
        {
            double somme = 0;

            for (int idx = 0; idx < m_nbPiquet - 1; idx++)
            {
                somme += (m_tabPiquet[idx].Abscisse + m_tabPiquet[idx + 1].Abscisse) * (m_tabPiquet[idx].Abscisse * m_tabPiquet[idx+1].Ordonner - m_tabPiquet[idx + 1].Abscisse * m_tabPiquet[idx].Ordonner);
                
            }
            somme += (m_tabPiquet[m_nbPiquet-1].Abscisse + m_tabPiquet[0].Abscisse)*(m_tabPiquet[m_nbPiquet-1].Abscisse*m_tabPiquet[0].Ordonner - m_tabPiquet[0].Abscisse*m_tabPiquet[m_nbPiquet-1].Ordonner) ;
            double AbscisseGravite = somme / (6*airePrairie);

            return AbscisseGravite;
        }

        public double CentreGraviteOrdonner(double airePrairie)
        {
            double somme = 0;

            for (int idx = 0; idx < m_nbPiquet - 1; idx++)
            {
                somme += (m_tabPiquet[idx].Ordonner + m_tabPiquet[idx + 1].Ordonner) * (m_tabPiquet[idx].Abscisse * m_tabPiquet[idx+1].Ordonner - m_tabPiquet[idx + 1].Abscisse * m_tabPiquet[idx].Ordonner);

            }
            somme += (m_tabPiquet[m_nbPiquet - 1].Ordonner + m_tabPiquet[0].Ordonner) * (m_tabPiquet[m_nbPiquet-1].Abscisse * m_tabPiquet[0].Ordonner - m_tabPiquet[0].Abscisse * m_tabPiquet[m_nbPiquet - 1].Ordonner);
            double OrdonnerGravite = somme / (6*airePrairie);

            return OrdonnerGravite;
        }

        public double AbscisseVecteur(int valeurPiquet)
        {
            double abscisse;
            if(valeurPiquet == m_nbPiquet-1)
            {
                abscisse = m_tabPiquet[0].Abscisse - m_tabPiquet[valeurPiquet].Abscisse;
            }
            else
            {
                abscisse = m_tabPiquet[valeurPiquet + 1].Abscisse - m_tabPiquet[valeurPiquet].Abscisse;
            }

            return abscisse;
        }

        public double OrdonnerVecteur(int valeurPiquet)
        {
            double Ordonner;
            if (valeurPiquet == m_nbPiquet - 1)
            {
                Ordonner = m_tabPiquet[0].Ordonner - m_tabPiquet[valeurPiquet].Ordonner;
            }
            else
            {
                Ordonner = m_tabPiquet[valeurPiquet + 1].Ordonner - m_tabPiquet[valeurPiquet].Ordonner;
            }

            return Ordonner;
        }

        public void  CoordonneVecteur(double airPrairie)
        {

            double abscisseGravite = CentreGraviteAbscisse(airPrairie);
            double ordonnerGravite = CentreGraviteOrdonner(airPrairie);
            Console.WriteLine("absisse = {0}", abscisseGravite);
            Console.WriteLine("ordonner ={0}", ordonnerGravite);
            m_coordonnerTab = new double[m_nbPiquet][];

            for (int idx = 0; idx < m_nbPiquet; idx++)
            {
                m_coordonnerTab[idx] = new double[2];
                m_coordonnerTab[idx][0] = m_tabPiquet[idx].Abscisse - abscisseGravite;
                m_coordonnerTab[idx][1] = m_tabPiquet[idx].Ordonner - ordonnerGravite;
                Console.WriteLine("coordonne = {0}, {1}", m_coordonnerTab[idx][0], m_coordonnerTab[idx][1]);
              
            }
            
           

        }

        public void ProduitScalaire()
        {
             m_produitScalaire = new double[m_nbPiquet];
            
            for (int idx = 0; idx < m_nbPiquet-1; idx++)
            {
                if (idx == m_nbPiquet-1)
                {
                    m_produitScalaire[idx] = m_coordonnerTab[idx][0] * m_coordonnerTab[0][0] + m_coordonnerTab[idx][1] * m_coordonnerTab[0][1];
                }
                else
                {
                    m_produitScalaire[idx] = m_coordonnerTab[idx][0] * m_coordonnerTab[idx + 1][0] + m_coordonnerTab[idx][1] * m_coordonnerTab[idx + 1][1];
                }
                
              
            }
      

        }

        public void NormeVecteur()
        {
            m_norme = new double[m_nbPiquet ];
            for (int idx = 0; idx < m_nbPiquet-1 ; idx++)
            {
                double somme = Math.Pow(m_coordonnerTab[idx][1], 2) + Math.Pow(m_coordonnerTab[idx][0], 2);
                m_norme[idx] = Math.Sqrt(somme);
            }

        }

        public void DeterminantVecteur()
        {
            m_determinant = new double[m_nbPiquet ];

            for (int idx = 0; idx < m_nbPiquet-1 ; idx++)
            {
                m_determinant[idx] = m_coordonnerTab[idx][0] * m_coordonnerTab[idx + 1][1] - m_coordonnerTab[idx][1] * m_coordonnerTab[idx +1][0];
            }
            

        }

        public double angle()
        {
            double somme = 0;
            double[] produitScalaire = new double[m_nbPiquet];
            double[] normeVecteur = new double[m_nbPiquet ];
            double[] determinant = new double[m_nbPiquet];
            ProduitScalaire();
            NormeVecteur();
            DeterminantVecteur();
            double angle;
            for (int idx = 0; idx < m_nbPiquet-1 ; idx++)
            {
               
               angle = Math.Acos(m_produitScalaire[idx] / m_norme[idx]);
                if (m_determinant[idx]<0)
                {
                    angle = -angle;
                }

                somme += angle;
              
            }

            return somme;

          
        }
    }
}
