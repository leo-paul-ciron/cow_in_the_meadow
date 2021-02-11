using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetTutorerTest
{   
    /*
        class Piquet, l'objet se construit à partir d'une ordonnée et d'une abscise ainsi que d'un id
        les attribut sont en private mais on définit la propriété get l'ordonnée et l'absice pour pouvoir
        les utilisés dans le programme. Cette class n'implémente aucune fonction.

     */
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
