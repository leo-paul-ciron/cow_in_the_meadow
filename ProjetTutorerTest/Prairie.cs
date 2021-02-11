using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetTutorerTest
{
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
        public Prairie(int p_nbPiquet, Piquet[] p_tabPiquet)
        {
            m_nbPiquet = p_nbPiquet;
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
