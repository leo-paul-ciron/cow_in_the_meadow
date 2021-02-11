using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetTutorerTest
{
     public class Piquet
    {
        private double m_ordonner;
        public double Ordonner
        {
            get{ return m_ordonner; }
        }
        private double m_abscise;
        public double Abscisse
        {
            get { return m_abscise; }
        }

        private int m_IdPiquet;

        public Piquet( double p_abscise,double p_ordonner, int p_IdPiquet)
        {
            m_ordonner = p_ordonner;
            m_abscise = p_abscise;
            m_IdPiquet = p_IdPiquet;
        }
    }
}
