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

        //la méthode permet de recupérer la valeur dans la variable m_ordonner
        public double Ordonner
        {
            get{ return m_ordonner; }
        }

        private double m_abscise;

        //la méthode permet de recupérer la valeur dans la variable m_abscisse
        public double Abscise
        {
            get { return m_abscise; }
        }

        private int m_IdPiquet;


        /*
         * constucteur de la classe Piquet, elle permet de fabriquer un objet Piquet à partir:
         *      -p_abscise -> correspondant à l'abscise du piquet
         *      -p_ordonner -> correspondant à l'ordonner du piquet
         *      -p_IdPiquet -> correspondant au numéro de Piquet fabriqué 
         *      
         * Le constructeur est basique, car il n'y a pas d'autre possibilitées pour fabriqué un piquet,
         * on ne peut pas mettre de coordonné par defaut.
         * 
        */

        public Piquet( double p_abscise,double p_ordonner, int p_IdPiquet)
        {
            m_ordonner = p_ordonner;
            m_abscise = p_abscise;
            m_IdPiquet = p_IdPiquet;
        }
    }
}
