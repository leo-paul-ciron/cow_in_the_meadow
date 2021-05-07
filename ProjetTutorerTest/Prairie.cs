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

        public double[][]  CoordonneVecteur(double airPrairie)
        {

            double abscisseGravite = CentreGraviteAbscisse(airPrairie);
            double ordonnerGravite = CentreGraviteOrdonner(airPrairie);

            m_coordonnerTab = new double[m_nbPiquet-1][];

            for (int idx = 0; idx < m_nbPiquet-1; idx++)
            {
                m_coordonnerTab[idx] = new double[1];
                m_coordonnerTab[idx][0] = m_tabPiquet[idx].Abscisse - abscisseGravite;
                m_coordonnerTab[idx][1] = m_tabPiquet[idx].Ordonner - ordonnerGravite;

                
            }

            return m_coordonnerTab;

        }

        public double[] ProduitScalaire()
        {
            double[] produitScalaire = new double[m_nbPiquet - 1];
            
            for (int idx = 0; idx < m_nbPiquet-1; idx++)
            {
                produitScalaire[idx] = m_coordonnerTab[idx][0] * m_coordonnerTab[idx + 1][0] + m_coordonnerTab[idx][1] * m_coordonnerTab[idx + 1][1];
            }
      

            return produitScalaire;
        }

        public double[] NormeVecteur()
        {
            double[] NormeVecteur = new double[m_nbPiquet - 1];
            for (int idx = 0; idx < m_nbPiquet - 1; idx++)
            {
                double somme = Math.Pow(m_coordonnerTab[idx][1], 2) + Math.Pow(m_coordonnerTab[idx][0], 2);
                NormeVecteur[idx] = Math.Sqrt(somme);
            }
      
            

            return NormeVecteur;
        }

        public double[] DeterminantVecteur()
        {
            double[] Determinant = new double[m_nbPiquet - 1];

            for (int idx = 0; idx < m_nbPiquet - 1; idx++)
            {
                Determinant[idx] = m_coordonnerTab[idx][0] * m_coordonnerTab[idx + 1][1] - m_coordonnerTab[idx][1] * m_coordonnerTab[idx +1][0];
            }
            

            return Determinant;
        }

        public double[] angle()
        {
            double[] angle = new double[m_nbPiquet-1];
            double[] produitScalaire = new double[m_nbPiquet - 1];
            double[] normeVecteur = new double[m_nbPiquet - 1];
            produitScalaire = ProduitScalaire();
            normeVecteur = NormeVecteur();
            for (int idx = 0; idx < m_nbPiquet - 1; idx++)
            {
                angle[idx] = produitScalaire[idx] / normeVecteur[idx]; 
            }

            return angle;
        }
    }
}
