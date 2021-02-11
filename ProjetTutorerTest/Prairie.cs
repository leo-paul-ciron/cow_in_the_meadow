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
    }
}
